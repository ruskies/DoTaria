using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoTaria.Skins;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Heroes.Abaddon.Skins.Default
{
    [AutoloadEquip(EquipType.Body)]
    public sealed class AbaddonBodyItem : SkinBodyItem
    {
        public AbaddonBodyItem() : base("Abaddon's Cloak", "", 38, 24, ItemRarityID.Blue)
        {
        }
    }
}
