using DoTaria.Skins;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Heroes.Abaddon.Skins.Default
{
    [AutoloadEquip(EquipType.Legs)]
    public sealed class AbaddonLegsItem : SkinLegsItem
    {
        public AbaddonLegsItem() : base("Abaddon's Greaves", "", 22, 14, ItemRarityID.Blue)
        {
        }
    }
}
