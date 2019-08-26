using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Skins.ShadowFiend.Default
{
    [AutoloadEquip(EquipType.Head)]
    public sealed class ShadowFiendHead : SkinHeadItem
    {
        public ShadowFiendHead() : base("Shadow Fiend Head", "", 22, 28, ItemRarityID.White)
        {
        }
    }
}
