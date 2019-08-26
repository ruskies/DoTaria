using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Skins.Abaddon.Default
{
    [AutoloadEquip(EquipType.Body)]
    public sealed class AbaddonBodyItem : SkinBodyItem
    {
        public AbaddonBodyItem() : base("Abaddon's Cloak", "", 38, 24, ItemRarityID.Blue)
        {
        }
    }
}
