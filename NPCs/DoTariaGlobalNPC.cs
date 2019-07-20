using DoTaria.Players;
using Terraria;
using Terraria.ModLoader;

namespace DoTaria.NPCs
{
    public sealed class DoTariaGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            DoTariaPlayer dotarriaPlayer = DoTariaPlayer.Get(Main.LocalPlayer);

            if (dotarriaPlayer == null)
                return;

            if (npc.lastInteraction == Main.LocalPlayer.whoAmI)
                dotarriaPlayer.OnKilledNPC(npc);
        }
    }
}