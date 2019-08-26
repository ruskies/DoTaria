using Terraria;
using Terraria.ModLoader;

namespace DoTaria.Heroes.ShadowFiend.Abilities.Shadowrazes
{
    public sealed class DoTariaShadowFiendGlobalNPC : GlobalNPC
    {
        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            if (projectile.type != mod.ProjectileType<ShadowrazeProjectile>())
                return;


        }

        public override void AI(NPC npc)
        {
            

            base.AI(npc);
        }
    }
}