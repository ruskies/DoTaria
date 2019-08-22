using System.Linq;
using DoTaria.Helpers;
using DoTaria.Network;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private void OnEnterWorldNetworking(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient || player.whoAmI != Main.myPlayer)
                return;

            NetworkPacketManager.Instance.PlayerJoiningSynchronization.SendPacketToAllClients(player.whoAmI, player.whoAmI, Hero.UnlocalizedName, Level, false, AbilitiesHelper.SerializeAbilities(AcquiredAbilities.Values.ToArray()));
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
