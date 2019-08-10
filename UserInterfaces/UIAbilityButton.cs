using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace DoTaria.UserInterfaces
{
    public sealed class UIAbilityButton : UIImageButton
    {
        public UIAbilityButton(Texture2D texture, Texture2D cooldownTexture) : base(texture)
        {
            _cooldownTexture = cooldownTexture;
            percent = 0.0f;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            CalculatedStyle dims = base.GetDimensions();
            Effect effect = DoTaria.Instance.GetEffect("Effects/ProgressBar");

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.Default, RasterizerState.CullNone, effect, Main.UIScaleMatrix);

            effect.Parameters["uSourceRect"].SetValue(new Vector4(0, 0, 34, 34));
            effect.Parameters["uImageSize0"].SetValue(new Vector2(34, 34));
            effect.Parameters["uRotation"].SetValue(3f);
            effect.Parameters["uDirection"].SetValue(-1f);
            effect.Parameters["uSaturation"].SetValue(percent);
            effect.CurrentTechnique.Passes[0].Apply();

            spriteBatch.Draw(_cooldownTexture, dims.Position(), new Rectangle(0, 0, 32, 32), Color.White * 0.85f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.UIScaleMatrix);

            if (seconds > 0.0f)
                Utils.DrawBorderString(spriteBatch, seconds.ToString(), dims.Position() + new Vector2(12, 7) - new Vector2(2 * (seconds.ToString().Length - 1), 0), Color.White, 1);

            Texture2D unleveled = DoTaria.Instance.GetTexture("UserInterfaces/Abilities/AbilityUnlevel");

            Texture2D leveled = DoTaria.Instance.GetTexture("UserInterfaces/Abilities/AbilityLevel");

            for (int i = 0; i < maxLevel; i++)
                spriteBatch.Draw(unleveled, dims.Position() + new Vector2((9 - i * 2) + 6 * i, 34 + 4), null, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 1f);

            for (int i = 0; i < currentLevel; i++)
                spriteBatch.Draw(leveled, dims.Position() + new Vector2((9 - i * 2) + 6 * i, 34 + 4), null, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 1f);
        }

        private Texture2D _cooldownTexture;

        public float percent;

        public int seconds;

        public int maxLevel;

        public int currentLevel;
    }
}
