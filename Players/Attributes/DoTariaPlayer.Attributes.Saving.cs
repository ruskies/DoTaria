using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private void SaveAttributes(TagCompound tag)
        {
            tag.Add(nameof(Strength), Strength);
            tag.Add(nameof(Agility), Agility);
            tag.Add(nameof(Intelligence), Intelligence);
        }

        private void LoadAttributes(TagCompound tag)
        {

        }
    }
}
