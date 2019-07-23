using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private void SaveLevels(TagCompound tag)
        {
            tag.Add(nameof(Level), Level);
        }

        public void LoadLevels(TagCompound tag)
        {
            Level = tag.GetAsInt(nameof(Level));
        }


        public int Level { get; set; } = 1;
    }
}
