using Terraria.ModLoader.IO;

namespace DoTarria.Players
{
    public sealed partial class DoTarriaPlayer
    {
        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound();

            SaveHeroes(tag);

            return tag;
        }

        public override void Load(TagCompound tag)
        {
            LoadHeroes(tag);
        }
    }
}
