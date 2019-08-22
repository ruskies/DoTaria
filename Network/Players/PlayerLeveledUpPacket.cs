using System.IO;
using DoTaria.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Network.Players
{
    public sealed class PlayerLeveledUpPacket : NetworkPacket
    {
        public override bool Receive(BinaryReader reader, int fromWho)
        {
            int whichPlayer = reader.ReadInt32();
            int howManyLevels = reader.ReadInt32();

            if (Main.netMode == NetmodeID.Server)
                SendPacketToAllClients(fromWho, whichPlayer, howManyLevels);

            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(Main.player[whichPlayer]);
            dotariaPlayer.LevelUp(howManyLevels);

            return true;
        }


        protected override void SendPacket(ModPacket packet, int toWho, int fromWho, params object[] args)
        {
            packet.Send((int) args[0]);
            packet.Send((int) args[1]);

            packet.Send(toWho, fromWho);
        }
    }
}