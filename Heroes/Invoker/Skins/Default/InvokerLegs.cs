using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoTaria.Skins;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Heroes.Invoker.Skins.Default
{
    [AutoloadEquip(EquipType.Legs)]
    public sealed class InvokerLegs : SkinLegsItem
    {
        public InvokerLegs() : base("Invoker Legs", "", 22, 14, ItemRarityID.White)
        {
        }
    }
}
