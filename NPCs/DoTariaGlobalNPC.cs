using DoTaria.Players;
using Terraria;
using Terraria.ModLoader;

namespace DoTaria.NPCs
{
    public sealed class DoTariaGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(Main.LocalPlayer);

            if (dotariaPlayer == null)
                return;

            if (npc.lastInteraction == Main.LocalPlayer.whoAmI)
                dotariaPlayer.OnKilledNPC(npc);
        }
    }
}