using System.Collections.Generic;
using System.IO;
using System.Linq;
using DoTaria.Abilities;
using DoTaria.Helpers;
using DoTaria.Heroes;
using DoTaria.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Network.Players
{
    public sealed class PlayerJoiningSynchronizationPacket : NetworkPacket
    {
        public override bool Receive(BinaryReader reader, int fromWho)
        {
            int whichPlayer = reader.ReadInt32();
            string heroUnlocalizedName = reader.ReadString();
            int level = reader.ReadInt32();
            bool isResponse = reader.ReadBoolean();
            string serializedAbilities = reader.ReadString();

            if (Main.netMode == NetmodeID.Server)
                SendPacketToAllClients(fromWho, whichPlayer, heroUnlocalizedName, level, isResponse, serializedAbilities);

            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(Main.player[whichPlayer]);

            dotariaPlayer.Hero = HeroDefinitionManager.Instance[heroUnlocalizedName];
            dotariaPlayer.Level = level;

            if (!string.IsNullOrWhiteSpace(serializedAbilities))
            {
                Dictionary<AbilityDefinition, PlayerAbility> acquiredAbilities = new Dictionary<AbilityDefinition, PlayerAbility>();
                PlayerAbility[] playerAbilities = AbilitiesHelper.DeserializeAbilities(serializedAbilities);

                dotariaPlayer.AcquiredAbilities = acquiredAbilities;

                for (int i = 0; i < playerAbilities.Length; i++)
                    acquiredAbilities.Add(playerAbilities[i].Ability, playerAbilities[i]);
            }

            if (Main.netMode == NetmodeID.MultiplayerClient && !isResponse)
            {
                DoTariaPlayer localDotariaPlayer = DoTariaPlayer.Get(Main.LocalPlayer);

                NetworkPacketManager.Instance.PlayerJoiningSynchronization.SendPacket(whichPlayer, Main.myPlayer, Main.myPlayer, localDotariaPlayer.Hero.UnlocalizedName, localDotariaPlayer.Level, true, AbilitiesHelper.SerializeAbilities(localDotariaPlayer.AcquiredAbilities.Values.ToArray()));
            }

            return true;
        }

        protected override void SendPacket(ModPacket packet, int toWho, int fromWho, params object[] args)
        {
            packet.Write((int) args[0]);
            packet.Write((string) args[1]);
            packet.Write((int) args[2]);
            packet.Write((bool) args[3]);
            packet.Write((string) args[4]);

            packet.Send(toWho, fromWho);
        }
    }
}