using System.IO;
using DoTaria.Abilities;
using DoTaria.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Network.Players
{
    public sealed class PlayerAbilityLeveledUpPacket : NetworkPacket
    {
        public override bool Receive(BinaryReader reader, int fromWho)
        {
            int whichPlayer = reader.ReadInt32();
            string abilityName = reader.ReadString();
            int abilityLevel = reader.ReadInt32();

            if (Main.netMode == NetmodeID.Server)
                NetworkPacketManager.Instance.PlayerAbilityLeveledUp.SendPacketToAllClients(fromWho, whichPlayer, abilityName, abilityLevel);

            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(Main.player[whichPlayer]);

            dotariaPlayer.AcquireOrLevelUp(AbilityDefinitionManager.Instance[abilityName], networkCall: true);
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