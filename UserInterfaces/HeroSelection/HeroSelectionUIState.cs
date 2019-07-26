using System;
using System.Collections.Generic;
using System.Linq;
using DoTaria.Extensions;
using DoTaria.Heroes;
using DoTaria.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace DoTaria.UserInterfaces.HeroSelection
{
    public sealed class HeroSelectionUIState : UIState, IDisposable
    {
        public const int CHARACTER_SELECTION_MENU_ID = 1;

        private const float
            PADDING_X = 10f,
            PADDING_Y = 7f;

        private Dictionary<HeroDefinition, Texture2D> _heroesSelectionTextures = new Dictionary<HeroDefinition, Texture2D>();

        private UIPanel _mainPanel, _heroesPanel;
        private UIText _mainLabel;

        public HeroSelectionUIState(Mod mod)
        {
            Mod = mod;

            foreach (HeroDefinition hero in HeroDefinitionManager.Instance.Values.OrderBy(h => h.DisplayName))
            {
                Type heroType = hero.GetType();

                string path = heroType.GetTexturePathFromType();
                _heroesSelectionTextures.Add(hero, heroType.GetModFromType().GetTexture(path + "Selection"));
            }
        }

        public override void OnInitialize()
        {
            base.OnInitialize();

            InitializeMainPanel();
            InitializeHeroesPanel();

            float
                nextHeroX = 0,
                nextHeroY = 0,
                biggestHeroY = 0;

            CalculatedStyle heroesDimensions = _heroesPanel.GetDimensions();

            foreach (KeyValuePair<HeroDefinition, Texture2D> kvp in _heroesSelectionTextures)
            {
                UIImageButton heroButton = new UIImageButton(kvp.Value);

                heroButton.Left.Set(nextHeroX, 0f);
                heroButton.Top.Set(nextHeroY, 0f);

                nextHeroX += kvp.Value.Width + PADDING_X;

                if (biggestHeroY < kvp.Value.Height)
                    biggestHeroY = kvp.Value.Height;

                if (nextHeroX > heroesDimensions.Width)
                {
                    nextHeroX = 0;
                    nextHeroY += biggestHeroY + PADDING_Y;
                }

                heroButton.OnClick += (evt, element) => SelectHero(kvp.Key);

                _heroesPanel.Append(heroButton);
            }
        }

        private void InitializeMainPanel()
        {
            _mainPanel = new UIPanel();

            _mainPanel.Width.Set(0, 0.5f);
            _mainPanel.Height.Set(0, 0.75f);
            _mainPanel.Left.Set(0f, 0.25f);
            _mainPanel.Top.Set(0f, 0.2f);

            _mainPanel.SetPadding(25f);

            //_mainPanel.BackgroundColor = Color.Black;

            _mainLabel = new UIText("Select your Hero", 1f, true);
            _mainLabel.HAlign = 0.5f;
            _mainLabel.VAlign = 0.05f;

            _mainPanel.Append(_mainLabel);


            UIText cancelLabel = new UIText("Cancel", 1.2f);
            _mainPanel.Append(cancelLabel);

            cancelLabel.HAlign = 0.5f;
            cancelLabel.VAlign = 0.95f;

            cancelLabel.OnClick += (evt, element) =>
            {
                SelectedHero = null;
                Main.menuMode = CHARACTER_SELECTION_MENU_ID;
            };

            Append(_mainPanel);
        }

        private void InitializeHeroesPanel()
        {
            _heroesPanel = new UIPanel();

            _heroesPanel.Width.Set(0, 1f);
            _heroesPanel.Height.Set(0, 0.75f);

            _heroesPanel.Top.Set(_mainLabel.GetDimensions().Height + 100f, 0f);
            _heroesPanel.SetPadding(50f);

            //_heroesPanel.BackgroundColor = Color.Red;
            _heroesPanel.BackgroundColor = Color.Transparent;
            _heroesPanel.BorderColor = Color.Transparent;

            _mainPanel.Append(_heroesPanel);
        }


        private void SelectHero(HeroDefinition hero)
        {
            SelectedHero = hero;
            Main.menuMode = 2;
        }


        public void Dispose()
        {
            

            foreach (HeroDefinition hero in new Dictionary<HeroDefinition, Texture2D>(_heroesSelectionTextures).Keys)
            {
                _heroesSelectionTextures[hero].Dispose();
                _heroesSelectionTextures.Remove(hero);
            }

            _heroesSelectionTextures = null;
        }

        
        public Mod Mod { get; }

        public static HeroDefinition SelectedHero { get; internal set; }
    }
}
