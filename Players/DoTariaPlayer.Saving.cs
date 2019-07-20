using Terraria.ModLoader.IO;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer
    {
        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound();

            SaveHeroes(tag);
            SaveAghanims(tag);

            return tag;
        }

        public override void Load(TagCompound tag)
        {
            LoadHeroes(tag);
            LoadAghanims(tag);
        }
    }
}
