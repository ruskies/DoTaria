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
            if (HomeOntoPlayer == null && HomeOntoNPC == null)
                Main.NewText("Nothing to home onto!");

            projectile.velocity = DoTariaMath.CalculateSpeedForTarget(projectile.position, HomeOntoPlayer?.Center ?? HomeOntoNPC.Center, 15);

            for (int i = 0; i < 5; i++)
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke, newColor: Color.Black, Scale: 2f);


            projectile.rotation += MathHelper.ToRadians(20);

            if ((HomeOntoPlayer?.getRect() ?? HomeOntoNPC.getRect()).Contains((int) projectile.position.X, (int) projectile.position.Y))
                projectile.damage = DamageOnContact;

            if ((HomeOntoPlayer != null && !HomeOntoPlayer.active) || (HomeOntoNPC != null && !HomeOntoNPC.active))
                projectile.timeLeft = 0;

            base.AI();
        }


        public Player HomeOntoPlayer { get; set; }
        public NPC HomeOntoNPC { get; set; }
        public int DamageOnContact { get; set; }
    }
}
