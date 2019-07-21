using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DoTaria.Dusts
{
    public class ShadowTrail : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.5f;
            dust.noGravity = true;
            dust.noLight = true;
        }
        public override bool Update(Dust dust)
        {
            return true;
        }
    }
}
