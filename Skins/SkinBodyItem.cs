using Terraria.ModLoader;

namespace DoTaria.Skins
{
    [AutoloadEquip(EquipType.Body)]
    public abstract class SkinBodyItem : SkinItem
    {
        protected SkinBodyItem(string displayName, string tooltip, int width, int height, int rarity) : base(displayName, tooltip, width, height, rarity: rarity)
        {
        }

        public override bool DrawBody() => false;
    }
}
