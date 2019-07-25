using DoTaria.Dusts;
using DoTaria.Players;
using DoTaria.Skins;
using Microsoft.Xna.Framework;
using Terraria;
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
            Vector2 dustPosition = new Vector2(dotariaPlayer.player.position.X + 2f, dotariaPlayer.player.position.Y + 36);

            Dust.NewDust(dustPosition, 15, 12, mod.DustType<ShadowTrail>(), 0f, 0f, 0, new Color(255, 255, 255), 2.3f);
        }
    }
}
