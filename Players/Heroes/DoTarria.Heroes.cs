using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
