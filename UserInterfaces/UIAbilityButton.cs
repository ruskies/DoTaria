using DoTaria.Abilities;
using DoTaria.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace DoTaria.UserInterfaces
{
    public sealed class UIAbilityButton : UIImageButton
    {
        private readonly Texture2D _cooldownTexture;


        public UIAbilityButton(Texture2D texture, Texture2D cooldownTexture) : base(texture)
        {
            _cooldownTexture = cooldownTexture;
            Percent = 0.0f;
        }


        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            if (Ability != null)
            {

                CalculatedStyle dims = base.GetDimensions();
                Effect effect = DoTariaMod.Instance.GetEffect("Effects/ProgressBar");

                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, effect, Main.UIScaleMatrix);

                effect.Parameters["uSourceRect"].SetValue(new Vector4(0, 0, 34, 34));
                effect.Parameters["uImageSize0"].SetValue(new Vector2(34, 34));
                effect.Parameters["uRotation"].SetValue(3f);
                effect.Parameters["uDirection"].SetValue(-1f);
                effect.Parameters["uSaturation"].SetValue(Percent);
                effect.CurrentTechnique.Passes[0].Apply();

                spriteBatch.Draw(_cooldownTexture, dims.Position(), new Rectangle(0, 0, 32, 32), Color.White * 0.85f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);

                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.UIScaleMatrix);

                if (Seconds > 0.0f)
                    Utils.DrawBorderString(spriteBatch, Seconds.ToString(), dims.Position() + new Vector2(12, 7) - new Vector2(2 * (Seconds.ToString().Length - 1), 0), Color.White, 1);

                Texture2D unleveled = DoTariaMod.Instance.GetTexture("UserInterfaces/Abilities/AbilityUnlevel");

                Texture2D leveled = DoTariaMod.Instance.GetTexture("UserInterfaces/Abilities/AbilityLevel");

                float spacing = 0;

                if (Ability.MaxLevel != 0)
                    spacing = 32 / Ability.MaxLevel;

                if (Ability.MaxLevel > 0)
                {
                    for (int i = 0; i < Ability.MaxLevel; i++)
                        spriteBatch.Draw(unleveled, dims.Position() + new Vector2(spacing * 0.5f + spacing * i, 34 + 4), null, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 1f);

                    for (int i = 0; i < CurrentLevel; i++)
                        spriteBatch.Draw(leveled, dims.Position() + new Vector2(spacing * 0.5f + spacing * i, 34 + 4), null, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 1f);
                }

                if (IsMouseHovering)
                    DrawDescription(spriteBatch, Ability);

            }
        }

        private void DrawDescription(SpriteBatch spriteBatch, AbilityDefinition ability)
        {
            int PANEL_WIDTH = 300;
            int PANEL_HEIGHT = 64;

            Vector2 position = Main.MouseWorld + new Vector2(Main.cursorTextures[0].Width, Main.cursorTextures[0].Height * 2) - Main.screenPosition;

            spriteBatch.Draw(Main.magicPixel, position, new Rectangle(0, 0, PANEL_WIDTH, PANEL_HEIGHT), Color.Black * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            spriteBatch.Draw(Main.magicPixel, position + new Vector2(2, 2), new Rectangle(0, 0, PANEL_WIDTH - 4, 32), Color.Gray * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(Main.fontMouseText, ability.DisplayName, position + new Vector2(6, 8), Color.White);
            spriteBatch.DrawString(Main.fontMouseText, "Level: " + CurrentLevel, position + new Vector2(PANEL_WIDTH - 70, 8), Color.White);

            Texture2D manacostTexture = DoTariaMod.Instance.GetTexture("UserInterfaces/Abilities/ManacostIcon");
            Texture2D cooldownTexture = DoTariaMod.Instance.GetTexture("UserInterfaces/Abilities/CooldownIcon");

            DoTariaPlayer doTariaPlayer = Main.LocalPlayer.GetModPlayer<DoTariaPlayer>();

            if (doTariaPlayer.AcquiredAbilities.ContainsKey(ability))
            {
                string cooldownText = ability.InternalGetCooldown(doTariaPlayer).ToString();

                if (ability.InternalGetCooldown(doTariaPlayer) > 0)
                {
                    spriteBatch.Draw(cooldownTexture, position + new Vector2(10, PANEL_HEIGHT - 22), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
                    spriteBatch.DrawString(Main.fontMouseText, cooldownText, position + new Vector2(30, PANEL_HEIGHT - 24), Color.Gray);
                }

                if (ability.InternalGetManaCost(doTariaPlayer) > 0)
                {
                    spriteBatch.Draw(manacostTexture, position + new Vector2(PANEL_WIDTH / 2, PANEL_HEIGHT - 22), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
                    spriteBatch.DrawString(Main.fontMouseText, ability.InternalGetManaCost(doTariaPlayer).ToString(), position + new Vector2(PANEL_WIDTH / 2 + 20, PANEL_HEIGHT - 24), Color.Gray);
                }
            }
        }

        private string SpliceText(string text, int lineLength)
        {
            return Regex.Replace(text, "(.{" + lineLength + "})" + ' ', "$1" + Environment.NewLine);
        }

        public AbilityDefinition Ability { get; set; }

        public float Percent { get; set; }

        public int Seconds { get; set; }

        public int CurrentLevel { get; set; }
    }
}
