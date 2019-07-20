using Terraria.ModLoader;

namespace DoTaria.Skins
{
    [AutoloadEquip(EquipType.Legs)]
    public abstract class SkinLegsItem : SkinItem
    {
        protected SkinLegsItem(string displayName, string tooltip, int width, int height, int rarity) : base(displayName, tooltip, width, height, rarity: rarity)
        {
        }

        public override bool DrawLegs() => false;
    }
}
