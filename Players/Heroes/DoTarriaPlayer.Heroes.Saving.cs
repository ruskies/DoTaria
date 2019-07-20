using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoTarria.Players
{
    public sealed partial class DoTarriaPlayer : ModPlayer
    {
        private void SaveHeroes(TagCompound tag)
        {
            SaveShadowFiend(tag);
        }

        private void LoadHeroes(TagCompound tag)
        {
            LoadShadowFiend(tag);
        }
    }
}
