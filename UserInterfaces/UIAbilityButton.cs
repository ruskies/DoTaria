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
            _texture = texture;
            _cooldownTexture = cooldownTexture;
            percent = 0.0f;
        }
        private Texture2D _texture;
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            CalculatedStyle dims = base.GetDimensions();
            Effect effect = DoTaria.Instance.GetEffect("Effects/ProgressBar");
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.Default, RasterizerState.CullNone, effect, Main.UIScaleMatrix);

            effect.Parameters["uSourceRect"].SetValue(new Vector4(0, 0, 34, 34));
            effect.Parameters["uImageSize0"].SetValue(new Vector2(34, 34));
            effect.Parameters["uRotation"].SetValue(3f);
            effect.Parameters["uDirection"].SetValue(-1f);
            effect.Parameters["uSaturation"].SetValue(percent);
            effect.CurrentTechnique.Passes[0].Apply();

            spriteBatch.Draw(_cooldownTexture, dims.Position(), new Rectangle(0, 0, 32, 32), Color.White * 0.85f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.UIScaleMatrix);
            if (seconds > 0.0f)
                Utils.DrawBorderString(spriteBatch, seconds.ToString(), dims.Position() + new Vector2(12, 7) - new Vector2(2 * (seconds.ToString().Length - 1), 0), Color.White, 1);
        }
        private Texture2D _cooldownTexture;
        public float percent;
        public int seconds;
    }
}
