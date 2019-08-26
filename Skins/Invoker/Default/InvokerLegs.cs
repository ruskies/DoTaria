using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Skins.Invoker.Default
{
    [AutoloadEquip(EquipType.Legs)]
    public sealed class InvokerLegs : SkinLegsItem
    {
        public InvokerLegs() : base("Invoker Legs", "", 22, 14, ItemRarityID.White)
        {
        }
    }
}
