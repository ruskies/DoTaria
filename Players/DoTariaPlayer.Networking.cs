using System.Linq;
using DoTaria.Helpers;
using DoTaria.Network;
using DoTaria.Network.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private void OnEnterWorldNetworking(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient || player.whoAmI != Main.myPlayer)
                return;

            this.SendIfLocal(new PlayerJoiningSynchronizationPacket(this));
        }

        internal void OnKilledNPCNetwork(int npcId)
        {
            NPC npc = Main.npc[npcId];

            if (npc == null)
                return;

            OnKilledNPC(npc);
        }
    }
}
