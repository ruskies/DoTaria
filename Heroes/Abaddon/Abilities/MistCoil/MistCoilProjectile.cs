using DoTaria.Projectiles;
using Terraria;
using Terraria.ID;

namespace DoTaria.Heroes.Abaddon.Abilities.MistCoil
{
    public sealed class MistCoilProjectile : DoTariaProjectile
    {
        internal Player homeOntoPlayer = null;
        internal NPC homeOntoNPC = null;


        public MistCoilProjectile() : base("Mist Coil", 34, 34)
        {
        }


        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }


        
    }
}
