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
    public sealed class AbilitiesUIState : DoTariaUIState
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

        private readonly List<UIImageButton> _abilityButtons = new List<UIImageButton>();

        private readonly Dictionary<UIImageButton, UIImage> _abilityNotLearnedMasks = new Dictionary<UIImageButton, UIImage>();

        private readonly Dictionary<AbilityDefinition, UIImageButton> _abilityButtonsForAbilityDefinitions = new Dictionary<AbilityDefinition, UIImageButton>();
        private readonly Dictionary<UIImageButton, AbilityDefinition> _upgradeButtonsForAbilityDefinitions = new Dictionary<UIImageButton, AbilityDefinition>();

        private readonly Dictionary<UIImageButton, AbilityDefinition> _definitionsForAbilityButton = new Dictionary<UIImageButton, AbilityDefinition>();
        private readonly Dictionary<UIImageButton, UIImageButton> _upgradeButtonsForAbilityButtons = new Dictionary<UIImageButton, UIImageButton>();
        private readonly Dictionary<UIImageButton, UIImageButton> _abilityButtonsForUpgradeButtons = new Dictionary<UIImageButton, UIImageButton>();

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

            _mainPanel.Width.Set(_emptyAbilitySlot.Width * ABILITIES_COUNT + ABILITY_PADDING_X * (ABILITIES_COUNT - 1) + _panelPadding * 2, 0);
            _mainPanel.Height.Set(_emptyAbilitySlot.Height * 2, 0f);

            Append(_mainPanel);

            CalculatedStyle dimensions = _mainPanel.GetInnerDimensions();
            int xOffset = 0;

            for (int i = 0; i < ABILITIES_COUNT; i++)
            {
                UIImageButton abilityButton = new UIImageButton(_emptyAbilitySlot);

                abilityButton.VAlign = 0.5f;
                abilityButton.Left.Set(xOffset, 0);
                abilityButton.Id = "ABILITY_BUTTON_" + i;

                abilityButton.SetVisibility(ACTIVE_VISIBILITY, INACTIVE_VISIBILITY);

                _mainPanel.Append(abilityButton);
                _abilityButtons.Add(abilityButton);

                UIImage abilityNotLearned = new UIImage(_abilityNotLearned);
                _abilityNotLearnedMasks.Add(abilityButton, abilityNotLearned);

                abilityButton.Append(abilityNotLearned);

                _definitionsForAbilityButton.Add(abilityButton, null);

                UIImageButton upgradeButton = new UIImageButton(_upgradeButton);

                upgradeButton.Left.Set(xOffset, 0);
                upgradeButton.Top.Set(_emptyAbilitySlot.Height + 5, 0);
                upgradeButton.OnClick += OnAbilityUpgradeButtonClicked;
                upgradeButton.Id = "UPGRADE_BUTTON_" + i;

                _upgradeButtonsForAbilityButtons.Add(abilityButton, upgradeButton);
                _abilityButtonsForUpgradeButtons.Add(upgradeButton, abilityButton);
                _mainPanel.Append(upgradeButton);

                xOffset += _emptyAbilitySlot.Width + ABILITY_PADDING_X;
            }
        }


        public void OnPlayerEnterWorld(DoTariaPlayer dotariaPlayer)
        {
            foreach (UIImageButton imageButton in new Dictionary<UIImageButton, AbilityDefinition>(_definitionsForAbilityButton).Keys)
            {
                _definitionsForAbilityButton[imageButton] = null;
                imageButton.SetImage(_emptyAbilitySlot);
            }

            _abilityButtonsForAbilityDefinitions.Clear();
            _upgradeButtonsForAbilityDefinitions.Clear();

            foreach (AbilityDefinition ability in dotariaPlayer.Hero.Abilities)
            {
                if (ability.AlwaysShowInAbilitiesBar)
                {
                    UIImageButton imageButton = _abilityButtons[(int)ability.AbilitySlot];

                    _definitionsForAbilityButton[imageButton] = ability;
                    imageButton.SetImage(ability.Icon);

                    _abilityButtonsForAbilityDefinitions.Add(ability, imageButton);
                    _upgradeButtonsForAbilityDefinitions.Add(_upgradeButtonsForAbilityButtons[imageButton], ability);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _mainPanel.BackgroundColor = Mod.GetConfig<DoTariaClientConfiguration>().AbilityPanelBackgroundColor;
            _mainPanel.BorderColor = Mod.GetConfig<DoTariaClientConfiguration>().AbilityPanelBorderColor;

            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(Main.LocalPlayer);

            foreach (KeyValuePair<UIImageButton, UIImage> kvp in _abilityNotLearnedMasks)
            {
                if (!_definitionsForAbilityButton.ContainsKey(kvp.Key) || _definitionsForAbilityButton[kvp.Key] == null || dotariaPlayer.HasAbility(_definitionsForAbilityButton[kvp.Key]))
                    kvp.Value.ImageScale = 0f;
                else
                    kvp.Value.ImageScale = 1f;
            }

            foreach (AbilityDefinition ability in dotariaPlayer.DisplayedAbilities)
            {
                UIImageButton upgradeButton = GetUpgradeButtonForAbility(ability);
                UIImageButton abilityButton = GetAbilityButtonForAbility(ability);

                if (upgradeButton == null)
                    continue;

                bool shouldDisplay = dotariaPlayer.HasSpareLevels && ability.CanUnlock(dotariaPlayer) && (!dotariaPlayer.HasAbility(ability) || ability.InternalCanLevelUp(dotariaPlayer));
                ChangeUpgradeButton(upgradeButton, shouldDisplay);
            }
        }


        private void OnAbilityUpgradeButtonClicked(UIMouseEvent evt, UIElement element)
        {
            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(Main.LocalPlayer);
            UIImageButton upgradeButton = element as UIImageButton;

            if (upgradeButton == null)
            {
                Main.NewText("Upgrade button was null ?");
                return;
            }

            if (!_upgradeButtonsForAbilityDefinitions.ContainsKey(upgradeButton))
            {
                Main.NewText("Upgrade button was clicked when it shouldn't be accessible.");
                return;
            }

            AbilityDefinition ability = _upgradeButtonsForAbilityDefinitions[upgradeButton];

            if (!CanUpgradeAbility(dotariaPlayer, ability))
            {
                Main.NewText("Tried leveling an ability without meeting the requirements.");
                return;
            }

            dotariaPlayer.AcquireOrLevelUp(ability);
        }


        private bool CanUpgradeAbility(DoTariaPlayer dotariaPlayer, AbilityDefinition ability) =>
            ability.CanUnlock(dotariaPlayer) && (!dotariaPlayer.HasAbility(ability) || ability.InternalCanLevelUp(dotariaPlayer));

        private void ChangeUpgradeButton(UIImageButton button, bool visible)
        {
            button.Width = visible ? _abilityButtonsForUpgradeButtons[button].Width : StyleDimension.Empty;
            button.Height = visible ? new StyleDimension(_upgradeButton.Height, 0f) : StyleDimension.Empty;
            button.SetVisibility(visible ? 1f : 0f, visible ? 0.75f : 0f);
        }


        private UIImageButton GetAbilityButtonForAbility(AbilityDefinition ability)
        {
            if (!_abilityButtonsForAbilityDefinitions.ContainsKey(ability))
                return null;

            return _abilityButtonsForAbilityDefinitions[ability];
        }

        private UIImageButton GetUpgradeButtonForAbility(AbilityDefinition ability)
        {
            UIImageButton abilityButton = GetAbilityButtonForAbility(ability);

            if (abilityButton == null || !_upgradeButtonsForAbilityButtons.ContainsKey(abilityButton))
                return null;

            return _upgradeButtonsForAbilityButtons[abilityButton];
        }


        public Mod Mod { get; }
    }
}