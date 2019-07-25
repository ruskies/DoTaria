using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DoTaria.Heroes.ShadowFiend.Skins.Default
{
    public class ShadowTrail : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
            dust.alpha = 0;
        }

        public override bool Update(Dust dust)
        {
            dust.velocity *= new Vector2(0.85f, 0.85f);
            dust.rotation = dust.velocity.X / 2;
            dust.alpha += 10;

            return true;
        }
    }
}
