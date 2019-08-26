using Microsoft.Xna.Framework;
using Terraria;

namespace DoTaria.Dusts.Heroes.ShadowFiend.Default
{
    public class ShadowTrail : DoTariaDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.velocity *= new Vector2(0f, 0.5f);

            return true;
        }
    }
}
