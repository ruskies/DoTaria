using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Skins.Abaddon.Default
{
    [AutoloadEquip(EquipType.Head)]
    public sealed class AbaddonHeadItem : SkinHeadItem
    {
        public AbaddonHeadItem() : base("Abaddon's Hood", "", 24, 30, ItemRarityID.Blue)
        {
        }
    }
}
