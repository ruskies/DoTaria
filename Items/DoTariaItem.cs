﻿using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Items
{
    public abstract class DoTariaItem : ModItem
    {
        public const string
            TERRARIA_DESCRIPTION_TOOLTIP = "Tooltip0";

        private readonly string _displayName, _tooltip;
        private readonly int _width, _height;

        protected DoTariaItem(string displayName, string tooltip, int width, int height, int value = 0, int defense = 0, int rarity = ItemRarityID.White)
        {
            _displayName = displayName;
            _tooltip = tooltip;

            _width = width;
            _height = height;

            Value = value;
            Defense = defense;
            Rarity = rarity;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault(_displayName);
            Tooltip.SetDefault(_tooltip);
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            item.width = _width;
            item.height = _height;

            item.value = Value;
            item.defense = Defense;
            item.rare = Rarity;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            //Tooltip.SetDefault(_tooltip);

            PostModifyTooltips(tooltips);
            base.ModifyTooltips(tooltips);
        }

        public virtual void PostModifyTooltips(List<TooltipLine> tooltips)
        {
        }


        #region Utilities

        public const float GOLD_RATIO = 72.5f;

        public static int Dota2BuyPrice(int gold) => Item.buyPrice(gold: (int)Math.Ceiling(gold / GOLD_RATIO));

        public static int Dota2SellPrice(int gold) => Item.sellPrice(gold: (int)Math.Ceiling(gold / GOLD_RATIO));

        #endregion


        public int Value { get; }
        public int Defense { get; }
        public int Rarity { get; }
    }
}
