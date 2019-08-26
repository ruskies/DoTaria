using DoTaria.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace DoTaria.Illusions
{
    // look, Modprojectile is easiest to setup and projectiles have highest limit in vanilla

    //Basic illusion is based on illusions made by Rune of Illusions so its stats are matching those;
    public class BasicIllusion : ModProjectile
    {
        private int _health;

        private bool _hasSpawned;

        private const int ILLUSION_LIFESPAN = 4500; // 75 seconds, same as illusions made by rune of illusions

        private const int FRAME_WIDTH = 40;

        private const int FRAME_HEIGHT = 56;

        public virtual void OnIllusionSpawn()
        {
            MaxHealth = Owner.statLifeMax2;
            Health = Owner.statLife;

                HeadTexture = Owner.head == -1 ? null : Main.armorHeadTexture[Owner.head];

                ArmTexture = Owner.body == -1 ? null : Main.armorArmTexture[Owner.body];

                BodyTexture = Owner.body == -1 ? null : Main.armorBodyTexture[Owner.body];

                LegsTexture = Owner.legs == -1 ? null : Main.armorLegTexture[Owner.legs];

            projectile.timeLeft = ILLUSION_LIFESPAN;
            projectile.width = Owner.width;
            projectile.height = Owner.height;
            projectile.tileCollide = false;

            _hasSpawned = true;
        }

        public override bool PreAI()
        {
            if (!_hasSpawned)
                OnIllusionSpawn();

            return base.PreAI();
        }

        public override void AI()
        {
            projectile.velocity.Y += 0.3f;

            if(++projectile.frameCounter > 4)
            {
                if (++projectile.frame > 19)
                    projectile.frame = 0;
                projectile.frameCounter = 0;
            }

        }

        public override void PostAI()
        {
            projectile.velocity = Collision.TileCollision(projectile.position, projectile.velocity, projectile.width, projectile.height);
        }

        //fuck vanilla drawing amirite
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            return false;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.Hitbox.Contains(Main.MouseWorld.ToPoint()))
            {
                Main.NewText("YEET");
                string HPtext = Health < MaxHealth ? "(" + Health + "/" + MaxHealth + ")" : "";
                Utils.DrawBorderString(spriteBatch, Owner.name + " " + HPtext , Main.MouseWorld  + new Vector2(Main.cursorTextures[0].Width, Main.cursorTextures[0].Height)- Main.screenPosition, Main.mouseTextColorReal, 1);
            }
            Color drawColor = Color.White;
            Vector2 drawOrigin = new Vector2(FRAME_WIDTH / 2, FRAME_HEIGHT / 2);
            Rectangle drawFrame = new Rectangle(0, FRAME_HEIGHT * projectile.frame, FRAME_WIDTH, FRAME_HEIGHT);
            Vector2 drawPos = projectile.Center - new Vector2(0, 3);
            
            //thanks to Kazzymodus for fixing the shader <3
            Effect illusionShader = mod.GetEffect("Effects/Illusion");

            if (Main.myPlayer == Owner.whoAmI)
            {
                Main.spriteBatch.End();
                Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, illusionShader, Main.GameViewMatrix.ZoomMatrix);

                illusionShader.CurrentTechnique.Passes[0].Apply();
                illusionShader.Parameters["uColor"].SetValue(new Vector4(0.0f, 0.1f, 1.0f, 0.0f));
            }

            if (HeadTexture != null)
                spriteBatch.Draw(HeadTexture, drawPos - Main.screenPosition, drawFrame, drawColor, 0f, drawOrigin, 1f, SpriteEffects.None, 1f);
            if(BodyTexture != null)
                spriteBatch.Draw(BodyTexture, drawPos - Main.screenPosition, drawFrame, drawColor, 0f, drawOrigin, 1f, SpriteEffects.None, 1f);
            if (LegsTexture != null)
                spriteBatch.Draw(LegsTexture, drawPos - Main.screenPosition, drawFrame, drawColor, 0f, drawOrigin, 1f, SpriteEffects.None, 1f);
            if (ArmTexture != null)
                spriteBatch.Draw(ArmTexture, drawPos - Main.screenPosition, drawFrame, drawColor, 0f, drawOrigin, 1f, SpriteEffects.None, 1f);
           
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.GameViewMatrix.TransformationMatrix);
        }

        //Those are set to public in case illusion could be healed/damaged outside of illusion's implementation
        public int MaxHealth { get; private set; }
        public int Health
        {
            get => _health;
            set
            {
                _health += value;

                if (_health > MaxHealth)
                    _health = MaxHealth;

                if (_health < 0)
                    _health = 0;
            }
        }

        //Those are set to virtual so illusions could change them via simply overriding them.
        // Should those be set on Illusion's spawn instead?
        public virtual float DamageDealtMultiplier => 0.35f;
        public virtual float DamageTakenMeleeMultiplier => 2.0f; // melee illusion
        public virtual float DamageTakenRangedMultiplier => 3.0f; // ranged illusion

        private Texture2D HeadTexture { get; set; }

        private Texture2D BodyTexture { get; set; }

        private Texture2D ArmTexture { get; set; }

        private Texture2D LegsTexture { get; set; }

        //to simplify code for future. Might end up not using them (?)
        private Player Owner => Main.player[projectile.owner];
        private DoTariaPlayer DoTariaPlayer => Owner.GetModPlayer<DoTariaPlayer>();

        public virtual bool Invicible => false; // will come into play later, when I do Reflection 

        public override string Texture => "DoTaria/UserInterfaces/Abilities/AbilityUnlevel"; // shrug
    }
}
