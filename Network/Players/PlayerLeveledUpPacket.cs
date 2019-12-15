using System.IO;
using DoTaria.Players;
using Terraria;
using WebmilioCommons.Networking.Packets;

namespace DoTaria.Network.Players
{
    public sealed class PlayerLeveledUpPacket : ModPlayerNetworkPacket<DoTariaPlayer>
    {
        protected override bool PostReceive(BinaryReader reader, int fromWho)
        {
            DoTariaPlayer.Get(Main.player[Player.whoAmI]).LevelUp(LevelsCount);

            return base.PostReceive(reader, fromWho);
        }


        public int LevelsCount { get; set; }
    }
}