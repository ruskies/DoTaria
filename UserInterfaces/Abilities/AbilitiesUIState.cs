using System.Collections.Generic;
using DoTaria.Abilities;
using DoTaria.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace DoTaria.UserInterfaces.Abilities
{
    // Making code for interfaces is dogshit, I hate this class (but not too much cause I still made it and therefor have some inherent love for it)
    public class AbilitiesUIState : DoTariaUIState
    {
        private const string USERINTERFACE_ABILITIES_PREFIX = "UserInterfaces/Abilities/";
        private const int
            ABILITY_PADDING_X = 5,
            ABILITIES_COUNT = 6;

        private const float
            ACTIVE_VISIBILITY = 1f,
            INACTIVE_VISIBILITY = 0.75f;

        private DoTariaUIPanel _mainPanel;
        private Texture2D _emptyAbilitySlot, _abilityNotLearned, _abilityLevel, _abilityUnlevel, _upgradeButton;

        private readonly List<AbilityDefinition> _displayedAbilities = new List<AbilityDefinition>();
        private readonly List<UIImageButton> _abilityButtons = new List<UIImageButton>();
        private readonly Dictionary<UIImageButton, UIImage> _abilityNotLearnedMasks = new Dictionary<UIImageButton, UIImage>();
        private Dictionary<AbilityDefinition, UIImageButton> _buttonsPerDefinitions = new Dictionary<AbilityDefinition, UIImageButton>();
        private Dictionary<UIImageButton, AbilityDefinition> _definitionsPerButton = new Dictionary<UIImageButton, AbilityDefinition>();
        private Dictionary<UIImageButton, UIImageButton> _upgradeButtonsPerButtons = new Dictionary<UIImageButton, UIImageButton>();

        private readonly float _panelPadding;

        public AbilitiesUIState(Mod mod)
        {
            Mod = mod;

            _emptyAbilitySlot = mod.GetTexture(USERINTERFACE_ABILITIES_PREFIX + "EmptyAbility");
            _abilityNotLearned = mod.GetTexture(USERINTERFACE_ABILITIES_PREFIX + "NotLearnedAbility");

            _abilityLevel = mod.GetTexture(USERINTERFACE_ABILITIES_PREFIX + "AbilityLevel");
            _abilityUnlevel = mod.GetTexture(USERINTERFACE_ABILITIES_PREFIX + "AbilityUnlevel");

            _upgradeButton = mod.GetTexture(USERINTERFACE_ABILITIES_PREFIX + "UpgradeButton");

            _panelPadding = _emptyAbilitySlot.Height / 2f;
        }


        public override void OnInitialize()
        {
            base.OnInitialize();

            _mainPanel = new DoTariaUIPanel();

            _mainPanel.SetPadding(_panelPadding);
            _mainPanel.HAlign = 0.5f;
            _mainPanel.VAlign = 0.07f;

            _mainPanel.BackgroundColor = new Color(40, 40, 40, 100);

            _mainPanel.Width.Set(_emptyAbilitySlot.Width * ABILITIES_COUNT + ABILITY_PADDING_X * (ABILITIES_COUNT - 1) + _panelPadding * 2, 0);
            _mainPanel.Height.Set(_emptyAbilitySlot.Height * 2, 0f);

            Append(_mainPanel);

            CalculatedStyle dimensions = _mainPanel.GetInnerDimensions();
            int xOffset = 0;

            for (int i = 0; i < ABILITIES_COUNT; i++)
            {
                UIImageButton imageButton = new UIImageButton(_emptyAbilitySlot);

                imageButton.VAlign = 0.5f;
                imageButton.Left.Set(xOffset, 0);

                imageButton.SetVisibility(ACTIVE_VISIBILITY, INACTIVE_VISIBILITY);

                _mainPanel.Append(imageButton);

                xOffset += _emptyAbilitySlot.Width + ABILITY_PADDING_X;

                _abilityButtons.Add(imageButton);

                UIImage abilityNotLearned = new UIImage(_abilityNotLearned);
                _abilityNotLearnedMasks.Add(imageButton, abilityNotLearned);

                imageButton.Append(abilityNotLearned);

                _definitionsPerButton.Add(imageButton, null);
            }

            foreach (UIImageButton imageButton in _abilityButtons)
            {
                if (_definitionsPerButton[imageButton] == null)
                    continue;

                UIImageButton upgradeButton = new UIImageButton(_upgradeButton);
                Vector2 bottomLeft = imageButton.GetDimensions().ToRectangle().BottomLeft();

                upgradeButton.Left.Set(bottomLeft.X, 0);
                upgradeButton.Top.Set(bottomLeft.Y + 5, 0);

                _upgradeButtonsPerButtons.Add(imageButton, upgradeButton);
                imageButton.Append(upgradeButton);
            }
        }


        public void OnPlayerEnterWorld(DoTariaPlayer dotariaPlayer)
        {
            _displayedAbilities.Clear();

            foreach (UIImageButton imageButton in new Dictionary<UIImageButton, AbilityDefinition>(_definitionsPerButton).Keys)
            {
                _definitionsPerButton[imageButton] = null;
                imageButton.SetImage(_emptyAbilitySlot);
            }

            _buttonsPerDefinitions.Clear();

            foreach (AbilityDefinition ability in dotariaPlayer.Hero.Abilities)
            {
                if (ability.AlwaysShowInAbilitiesBar)
                {
                    _displayedAbilities.Add(ability);

                    UIImageButton imageButton = _abilityButtons[(int)ability.AbilitySlot];

                    _definitionsPerButton[imageButton] = ability;
                    imageButton.SetImage(ability.Icon);

                    _buttonsPerDefinitions.Add(ability, imageButton);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(Main.LocalPlayer);

            foreach (KeyValuePair<UIImageButton, UIImage> kvp in _abilityNotLearnedMasks)
            {
                if (!_definitionsPerButton.ContainsKey(kvp.Key) || _definitionsPerButton[kvp.Key] == null || dotariaPlayer.HasAbility(_definitionsPerButton[kvp.Key]))
                    kvp.Value.ImageScale = 0f;
                else
                    kvp.Value.ImageScale = 1f;
            }

            for (int i = 0; i < _displayedAbilities.Count; i++)
            {
                UIImageButton upgradeButton = GetUpgradeButtonForAbility(_displayedAbilities[i]);

                if (upgradeButton == null)
                    continue;

                bool shouldDisplay = _displayedAbilities[i].InternalCanLevelUp(dotariaPlayer);
                upgradeButton.SetVisibility(shouldDisplay ? 1f : 0f, shouldDisplay ? 0.80f : 0f);
            }
        }


        private UIImageButton GetAbilityButtonForAbility(AbilityDefinition ability)
        {
            if (!_buttonsPerDefinitions.ContainsKey(ability))
                return null;

            return _buttonsPerDefinitions[ability];
        }

        private UIImageButton GetUpgradeButtonForAbility(AbilityDefinition ability)
        {
            UIImageButton abilityButton = GetAbilityButtonForAbility(ability);

            if (abilityButton == null || !_upgradeButtonsPerButtons.ContainsKey(abilityButton))
                return null;

            return _upgradeButtonsPerButtons[abilityButton];
        }


        public Mod Mod { get; }
    }
}