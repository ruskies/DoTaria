using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
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
