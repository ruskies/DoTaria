using System.Collections.Generic;
using DoTaria.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Items.Aghanims
{
    public sealed class AghanimsScepter : DoTariaItem, IGiveAghanimUpgrade
    {
        public const string TOOLTIP_AGHANIMS_UPGRADE = "AGHANIMS_UPGRADE";


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


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);

            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(Main.LocalPlayer);
            string tooltip = dotariaPlayer.Hero.GetAghanimsUpgrade(dotariaPlayer);

            if (string.IsNullOrWhiteSpace(tooltip))
                tooltip = "This hero has no Aghanim's upgrade";

            tooltips.Add(new TooltipLine(mod, TOOLTIP_AGHANIMS_UPGRADE, tooltip));
        }
    }
}
