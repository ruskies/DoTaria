using DoTaria.Helpers;
using DoTaria.Network;
using DoTaria.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.NPCs
{
    public sealed class DoTariaGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.lastInteraction == 255) return; // Killed by a non-player.

            if (Main.netMode == NetmodeID.Server)
                NetworkPacketManager.Instance.PlayerKilledNPC.SendPacketToAllClients(255, npc.lastInteraction, NPCsHelper.GetNPCIdFromNPC(npc));
            else if (npc.lastInteraction != Main.myPlayer) return; // Killed by someone else.

            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(Main.LocalPlayer);

            if (dotariaPlayer == null)
                return;

            if (npc.lastInteraction == Main.myPlayer)
                dotariaPlayer.OnKilledNPC(npc);
        }
    }
}