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
        }

        public override bool Update(Dust dust)
        {
            dust.velocity *= new Vector2(0f, 0.5f);

            return true;
        }
    }
}
