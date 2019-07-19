using Terraria;
using Terraria.ModLoader;

namespace DoTarria.Players
{
    public sealed partial class DoTarriaPlayer : ModPlayer
    {
        public static DoTarriaPlayer Get(Player player) => player.GetModPlayer<DoTarriaPlayer>();

        public void OnKilledNPC(NPC npc)
        {
            // TODO Replace this with ability check.


        }
    }
}
