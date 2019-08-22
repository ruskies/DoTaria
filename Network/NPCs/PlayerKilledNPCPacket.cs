using System.IO;
using DoTaria.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Network.NPCs
{
    public sealed class PlayerKilledNPCPacket : NetworkPacket
    {
        public override bool Receive(BinaryReader reader, int fromWho)
        {
            int whichPlayer = reader.ReadInt32();
            int npcId = reader.ReadInt32();

            if (Main.netMode == NetmodeID.Server)
                NetworkPacketManager.Instance.PlayerKilledNPC.SendPacketToAllClients(fromWho, whichPlayer, npcId);

            DoTariaPlayer.Get(Main.player[whichPlayer]).OnKilledNPCNetwork(npcId);

            return true;
        }

        protected override void SendPacket(ModPacket packet, int toWho, int fromWho, params object[] args)
        {
            packet.Write((int)args[0]);
            packet.Write((int)args[1]);

            packet.Send(toWho, fromWho);
        }
    }
}