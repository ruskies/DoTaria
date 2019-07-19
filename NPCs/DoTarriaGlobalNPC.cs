using DoTarria.Players;
using Terraria;
using Terraria.ModLoader;

namespace DoTarria.NPCs
{
    public sealed class DoTarriaGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            DoTarriaPlayer dotarriaPlayer = DoTarriaPlayer.Get(Main.LocalPlayer);

            if (dotarriaPlayer == null)
                return;

            if (npc.lastInteraction == Main.LocalPlayer.whoAmI)
                dotarriaPlayer.OnKilledNPC(npc);
        }
    }
}