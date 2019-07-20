using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private int _souls;

        private void SaveShadowFiend(TagCompound tag)
        {
            tag.Add(nameof(Souls), Souls);
        }

        private void LoadShadowFiend(TagCompound tag)
        {
            Souls = tag.GetAsInt(nameof(Souls));
        }

        public int Souls
        {
            get => _souls;
            set
            {
                if (value == _souls || value > 36)
                    return;

                _souls = value;
            }
        }
    }
}
