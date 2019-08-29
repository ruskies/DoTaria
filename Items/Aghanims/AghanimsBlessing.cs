using System.Collections.Generic;
using DoTaria.Extensions;
using DoTaria.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Items.Aghanims
{
    public sealed class AghanimsBlessing : DoTariaItem
    {
        public AghanimsBlessing() : base("Aghanim's Blessing", "The scepter of a wizard with demigod-like powers, in a drinkable format.\nMay cause stomach aches.", 20, 38, 
            value: Dota2BuyPrice(6200), rarity: ItemRarityID.Expert)
        {
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            item.expertOnly = true;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.EatingUsing;

            item.useAnimation = 25;
            item.useTime = 25;
        }

        public override void AddRecipes()
        {
            base.AddRecipes();

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient<AghanimsScepter>();

            recipe.SetResult(this);
            recipe.AddRecipe();
        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);

            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(Main.LocalPlayer);
            string tooltip = dotariaPlayer.Hero.GetAghanimsUpgrade(dotariaPlayer);

            if (string.IsNullOrWhiteSpace(tooltip))
                tooltip = "This hero has no Aghanim's upgrade";

            tooltips.Add(new TooltipLine(mod, AghanimsScepter.TOOLTIP_AGHANIMS_UPGRADE, tooltip));
        }


        public override bool CanUseItem(Player player) => !player.GetModPlayer<DoTariaPlayer>().AghanimsBlessingConsumed;

        public override bool UseItem(Player player) => player.GetModPlayer<DoTariaPlayer>().AghanimsBlessingConsumed = true;
    }
}
