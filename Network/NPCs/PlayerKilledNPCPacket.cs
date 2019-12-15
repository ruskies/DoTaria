using System.IO;
using DoTaria.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Networking.Packets;

namespace DoTaria.Network.NPCs
{
    public sealed class PlayerKilledNPCPacket : ModPlayerNetworkPacket<DoTariaPlayer>
    {
        protected override bool PostReceive(BinaryReader reader, int fromWho)
        {
            DoTariaPlayer.Get(Main.player[Player.whoAmI]).OnKilledNPCNetwork(NPCId);

            return base.PostReceive(reader, fromWho);
        }

        public int NPCId { get; set; }
    }
}