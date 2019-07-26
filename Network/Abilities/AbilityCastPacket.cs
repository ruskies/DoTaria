using System.IO;
using DoTaria.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Network.Abilities
{
    public sealed class AbilityCastPacket : NetworkPacket
    {
        public override bool Receive(BinaryReader reader, int fromWho)
        {
            byte whichPlayer = reader.ReadByte();
            string abilityName = reader.ReadString();

            if (Main.netMode == NetmodeID.Server)
                SendPacketToAllClients(fromWho, whichPlayer, abilityName);

            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(Main.player[whichPlayer]);
            // TODO Add player cast method.

            return true;
        }

        protected override void SendPacket(ModPacket packet, int toWho, int fromWho, params object[] args)
        {
            packet.Write((byte) args[0]);
            packet.Write((string) args[1]);

            packet.Send(toWho, fromWho);
        }
    }
}
