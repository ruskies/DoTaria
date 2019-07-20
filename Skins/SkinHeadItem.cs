using Terraria.ModLoader;

namespace DoTaria.Skins
{
    [AutoloadEquip(EquipType.Head)]
    public abstract class SkinHeadItem : SkinItem
    {
        protected SkinHeadItem(string displayName, string tooltip, int width, int height, int rarity) : base(displayName, tooltip, width, height, rarity: rarity)
        {
        }

        public override bool DrawHead() => false;
    }
}
