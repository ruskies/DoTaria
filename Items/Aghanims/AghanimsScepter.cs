using Terraria.ID;

namespace DoTaria.Items.Aghanims
{
    public sealed class AghanimsScepter : DoTariaItem, IGiveAghanimUpgrade
    {
        public AghanimsScepter() : base("Aghanim's Scepter", "The scepter of a wizard with demigod-like powers.", 46, 46,
            value: Dota2BuyPrice(4200), rarity: ItemRarityID.Cyan)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            item.accessory = true;
            item.maxStack = 1;
        }
    }
}
