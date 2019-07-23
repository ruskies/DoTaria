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
    [AutoloadEquip(EquipType.Head)]
    public sealed class AbaddonHeadItem : SkinHeadItem
    {
        public AbaddonHeadItem() : base("Abaddon's Hood", "", 24, 30, ItemRarityID.Blue)
        {
        }
    }
}
