using DoTaria.Dusts;
using DoTaria.Players;
using DoTaria.Skins;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Heroes.ShadowFiend.Skins.Default
{
    [AutoloadEquip(EquipType.Legs)]
    public sealed class ShadowFiendLegs : SkinLegsItem, ISpawnDustOnPlayerPostUpdate
    {
        public ShadowFiendLegs() : base("Shadow Fiend Legs", "", 14, 20, ItemRarityID.White)
        {
        }

        public void SpawnDustOnPlayerPostUpdate(DoTariaPlayer dotariaPlayer)
        {
            
        }
    }
}
