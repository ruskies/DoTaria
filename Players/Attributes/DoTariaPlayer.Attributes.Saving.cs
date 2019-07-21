using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        public float Strength
        {
            get
            {
                return Hero.BaseStrength;
            }
        }
    }
}
