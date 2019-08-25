using DoTaria.Skins;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Heroes.Invoker.Skins.Default
{
    [AutoloadEquip(EquipType.Body)]
    public sealed class InvokerBody : SkinBodyItem
    {
        public InvokerBody() : base("Invoker Body", "", 42, 28, ItemRarityID.White)
        {
        }
    }
}