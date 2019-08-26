using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Skins.Invoker.Default
{
    [AutoloadEquip(EquipType.Body)]
    public sealed class InvokerBody : SkinBodyItem
    {
        public InvokerBody() : base("Invoker Body", "", 42, 28, ItemRarityID.White)
        {
        }
    }
}