using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoTarria.Players
{
    public sealed partial class DoTarriaPlayer : ModPlayer
    {
        private void SaveShadowFiend(TagCompound tag)
        {
            tag.Add(nameof(Souls), Souls);
        }

        private void LoadShadowFiend(TagCompound tag)
        {
            Souls = tag.GetAsInt(nameof(Souls));
        }

        public int Souls { get; private set; }
    }
}
