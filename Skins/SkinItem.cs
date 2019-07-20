using DoTaria.Items;

namespace DoTaria.Skins
{
    public abstract class SkinItem : DoTariaItem
    {
        protected SkinItem(string displayName, string tooltip, int width, int height, int rarity) : base(displayName, tooltip, width, height, rarity: rarity)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            item.vanity = true;
        }
    }
}
