using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DoTaria.Extensions
{
    public static class ProjectileExtensions
    {
        public static Vector2 GetProjectilePosition(this Projectile projectile) => projectile.position - Main.screenPosition;
    }
}
