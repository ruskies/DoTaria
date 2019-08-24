using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoTaria.Extensions;
using DoTaria.Heroes.ShadowFiend.Skins.Default;
using DoTaria.Items;
using DoTaria.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Heroes.ShadowFiend.Abilities.Shadowrazes
{
    public sealed class ShadowrazeProjectile : DoTariaProjectile
    {
        public const int FRAME_COUNT = 5, FRAME_PER_FRAME = 4, TIME_LEFT = FRAME_COUNT * FRAME_PER_FRAME;

        private int _currentFrame = 0;

        public ShadowrazeProjectile() : base("Shadowraze", 124, 800 / FRAME_COUNT)
        {
        }


        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Main.projFrames[projectile.type] = FRAME_COUNT;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.damage = 400;
            projectile.alpha = 255;
            projectile.timeLeft = TIME_LEFT;

            projectile.friendly = true;
            projectile.penetrate = -1;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
        }


        public override void AI()
        {
            projectile.netUpdate = true;
            projectile.frameCounter++;

            if (projectile.frameCounter % FRAME_PER_FRAME == 0)
                _currentFrame++;
        }

        // Thank you ExampleMod.
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = Main.projectileTexture[projectile.type];
            int startY = (texture.Height / FRAME_COUNT) * _currentFrame;

            Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, texture.Height / FRAME_COUNT);
            //Vector2 origin = sourceRectangle.Size() / 2;

            Main.spriteBatch.Draw(texture, projectile.GetProjectilePosition(), sourceRectangle, Color.White);

            return false;
        }
    }

    public sealed class ShadowrazeTestItem : DoTariaItem
    {
        public ShadowrazeTestItem() : base("Shadowraze Point & Click", "This is a test item, you shouldn't have this >:(", 24, 24)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            item.useTime = 25;
            item.useAnimation = 25;

            item.useStyle = ItemUseStyleID.Stabbing;
        }

        public override bool UseItem(Player player)
        {
            if (player != Main.LocalPlayer || Main.netMode == NetmodeID.Server)
                return false;

            Projectile.NewProjectile(Main.MouseWorld - new Vector2(0, typeof(ShadowrazeProjectile).GetTexture().Height / (ShadowrazeProjectile.FRAME_COUNT * 2f) - 25), Vector2.Zero, mod.ProjectileType<ShadowrazeProjectile>(), 400, 0, player.whoAmI);
            return true;
        }
    }
}
