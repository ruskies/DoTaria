using DoTaria.Commons;
using DoTaria.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace DoTaria.Heroes.Abaddon.Abilities.MistCoil
{
    public sealed class MistCoilProjectile : DoTariaProjectile
    {
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
            projectile.friendly = true;
        }


        public override void AI()
        {
            projectile.netUpdate = true;
            projectile.rotation += MathHelper.ToRadians(20);

            if (HomeOntoPlayer == null && HomeOntoNPC == null) return;

            projectile.velocity = DoTariaMath.CalculateSpeedForTarget(projectile.position, HomeOntoPlayer?.Center ?? HomeOntoNPC.Center, 15);

            for (int i = 0; i < 5; i++)
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke, newColor: Color.Black, Scale: 2f);


            if (HomeOntoPlayer != null && HomeOntoPlayer.getRect().Contains((int) projectile.position.X, (int) projectile.position.Y))
            {
                HomeOntoPlayer.statLife += DamageOnContact;
                HomeOntoPlayer.HealEffect(DamageOnContact);

                projectile.timeLeft = 0;
            }
            else if (HomeOntoNPC != null && HomeOntoNPC.getRect().Contains((int) projectile.position.X, (int) projectile.position.Y))
            {
                projectile.damage = DamageOnContact;
                projectile.timeLeft = 0;
            }


            if ((HomeOntoPlayer != null && !HomeOntoPlayer.active) || (HomeOntoNPC != null && !HomeOntoNPC.active))
                projectile.timeLeft = 0;

            base.AI();
        }


        public Player HomeOntoPlayer { get; set; }
        public NPC HomeOntoNPC { get; set; }
        public int DamageOnContact { get; set; }
    }
}
