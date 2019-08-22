using System.IO;
using DoTaria.Abilities;
using DoTaria.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Network.Abilities
{
    public sealed class AbilityCastedPacket : NetworkPacket
    {
        public override bool Receive(BinaryReader reader, int fromWho)
        {
            int whichPlayer = reader.ReadInt32();
            string abilityName = reader.ReadString();
            int newCooldown = reader.ReadInt32();

            if (Main.netMode == NetmodeID.Server)
                SendPacketToAllClients(fromWho, whichPlayer, abilityName, newCooldown);

            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(Main.player[whichPlayer]);
            PlayerAbility playerAbility = dotariaPlayer.AcquiredAbilities[AbilityDefinitionManager.Instance[abilityName]];

            playerAbility.Ability.InternalCastAbility(dotariaPlayer, playerAbility, false);
            playerAbility.Cooldown = newCooldown;

            return true;
        }

        protected override void SendPacket(ModPacket packet, int toWho, int fromWho, params object[] args)
        {
            packet.Write((int) args[0]);
            packet.Write((string) args[1]);
            packet.Write((int) args[2]);

            packet.Send(toWho, fromWho);
        }
    }
}
