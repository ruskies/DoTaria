﻿using DoTaria.Skins;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Heroes.ShadowFiend.Skins.Default
{
    [AutoloadEquip(EquipType.Body)]
    public sealed class ShadowFiendBody : SkinBodyItem
    {
        public ShadowFiendBody() : base("Shadow Fiend Body", "", 42, 34, ItemRarityID.Blue)
        {
        }
    }
}
