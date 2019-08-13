using System.Collections.Generic;
using DoTaria.Abilities;
using DoTaria.Commons;
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
            COOLDOWN_VISIBILITY = 0.65f,
            INACTIVE_VISIBILITY = 0.5f;

        private DoTariaUIPanel _mainPanel;
        private readonly Texture2D _emptyAbilitySlot, _abilityNotLearned, _abilityLevel, _abilityUnlevel, _upgradeButton;

        private readonly List<UIAbilityButton> _abilityButtons = new List<UIAbilityButton>();

        // I have acquired the will to commit toaster bath :)
        private readonly Dictionary<UIAbilityButton, UIImage> _abilityNotLearnedMasks = new Dictionary<UIAbilityButton, UIImage>();

        private readonly Dictionary<AbilityDefinition, UIAbilityButton> _abilityButtonsForAbilityDefinitions = new Dictionary<AbilityDefinition, UIAbilityButton>();
        private readonly Dictionary<UIAbilityButton, AbilityDefinition> _upgradeButtonsForAbilityDefinitions = new Dictionary<UIAbilityButton, AbilityDefinition>();

        private readonly Dictionary<UIAbilityButton, AbilityDefinition> _definitionsForAbilityButton = new Dictionary<UIAbilityButton, AbilityDefinition>();
        private readonly Dictionary<UIAbilityButton, UIAbilityButton> _upgradeButtonsForAbilityButtons = new Dictionary<UIAbilityButton, UIAbilityButton>();
        private readonly Dictionary<UIAbilityButton, UIAbilityButton> _abilityButtonsForUpgradeButtons = new Dictionary<UIAbilityButton, UIAbilityButton>();

        private readonly Dictionary<UIAbilityButton, UIText> _cooldownTextPerAbilityButtons = new Dictionary<UIAbilityButton, UIText>();
        private readonly Dictionary<UIAbilityButton, UIText> _leveledTextPerAbilityButtons = new Dictionary<UIAbilityButton, UIText>();

        private readonly float _panelPadding;

        private readonly Texture2D _cooldownTexture;

        public AbilitiesUIState(Mod mod)
        {
            Mod = mod;

            _cooldownTexture = mod.GetTexture(USERINTERFACE_ABILITIES_PREFIX + "CooldownTexture");

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

            int xOffset = 0;

            for (int i = 0; i < ABILITIES_COUNT; i++)
            {
                UIAbilityButton abilityButton = new UIAbilityButton(_emptyAbilitySlot, _cooldownTexture);

                abilityButton.VAlign = 0.5f;
                abilityButton.Left.Set(xOffset, 0);
                abilityButton.SetVisibility(ACTIVE_VISIBILITY, INACTIVE_VISIBILITY);


                UIImage abilityNotLearned = new UIImage(_abilityNotLearned);
                _abilityNotLearnedMasks.Add(abilityButton, abilityNotLearned);

                abilityButton.Append(abilityNotLearned);

                _definitionsForAbilityButton.Add(abilityButton, null);

                UIAbilityButton upgradeButton = new UIAbilityButton(_upgradeButton, _cooldownTexture);

                upgradeButton.Top.Set(-22, 0);
                upgradeButton.Left.Set(xOffset, 0);
                upgradeButton.OnClick += OnAbilityUpgradeButtonClicked;

                _upgradeButtonsForAbilityButtons.Add(abilityButton, upgradeButton);
                _abilityButtonsForUpgradeButtons.Add(upgradeButton, abilityButton);
                _mainPanel.Append(upgradeButton);
                _mainPanel.Append(abilityButton);
                _abilityButtons.Add(abilityButton);

                xOffset += _emptyAbilitySlot.Width + ABILITY_PADDING_X;
            }
        }

        public void OnPlayerEnterWorld(DoTariaPlayer dotariaPlayer)
        {
            foreach (UIAbilityButton imageButton in new Dictionary<UIAbilityButton, AbilityDefinition>(_definitionsForAbilityButton).Keys)
            {
                _definitionsForAbilityButton[imageButton] = null;
                imageButton.SetImage(_emptyAbilitySlot);
            }

            _abilityButtonsForAbilityDefinitions.Clear();
            _upgradeButtonsForAbilityDefinitions.Clear();

            _cooldownTextPerAbilityButtons.Clear();
            _leveledTextPerAbilityButtons.Clear();

            foreach (AbilityDefinition ability in dotariaPlayer.Hero.Abilities)
            {
                if (ability.AlwaysShowInAbilitiesBar)
                {
                    UIAbilityButton imageButton = _abilityButtons[(int)ability.AbilitySlot];

                    _definitionsForAbilityButton[imageButton] = ability;
                    imageButton.SetImage(ability.Icon);

                    _abilityButtonsForAbilityDefinitions.Add(ability, imageButton);
                    _upgradeButtonsForAbilityDefinitions.Add(_upgradeButtonsForAbilityButtons[imageButton], ability);


                    UIAbilityButton abilityButton = GetAbilityButtonForAbility(ability);
                    abilityButton.CurrentLevel = 0;
                    abilityButton.MaxLevel = 0;

                }
            }
            foreach (var button in _abilityButtons)
            {
                button.MaxLevel = 0;
                button.CurrentLevel = 0;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _mainPanel.BackgroundColor = Mod.GetConfig<DoTariaClientConfiguration>().AbilityPanelBackgroundColor;
            _mainPanel.BorderColor = Mod.GetConfig<DoTariaClientConfiguration>().AbilityPanelBorderColor;

            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(Main.LocalPlayer);

            foreach (KeyValuePair<UIAbilityButton, UIImage> kvp in _abilityNotLearnedMasks)
            {
                if (!_definitionsForAbilityButton.ContainsKey(kvp.Key) || _definitionsForAbilityButton[kvp.Key] == null || dotariaPlayer.HasAbility(_definitionsForAbilityButton[kvp.Key]))
                    kvp.Value.ImageScale = 0f;
                else
                    kvp.Value.ImageScale = 1f;
            }

            foreach (var button in _upgradeButtonsForAbilityButtons)
            {
                ChangeUpgradeButton(button.Value, false);
            }

            foreach (AbilityDefinition ability in dotariaPlayer.DisplayedAbilities)
            {
                UIAbilityButton upgradeButton = GetUpgradeButtonForAbility(ability);
                UIAbilityButton abilityButton = GetAbilityButtonForAbility(ability);

                if (dotariaPlayer.AcquiredAbilities.Count > 0)
                {
                    if (dotariaPlayer.AcquiredAbilities.ContainsKey(ability))
                    {
                        float percent = (float)(dotariaPlayer.AcquiredAbilities[ability].Cooldown / (ability.GetCooldown(dotariaPlayer, dotariaPlayer.AcquiredAbilities[ability]) * DoTariaMath.TICKS_PER_SECOND));

                        abilityButton.Percent = percent;
                        abilityButton.CurrentLevel = dotariaPlayer.AcquiredAbilities[ability].Level;
                        abilityButton.MaxLevel = ability.MaxLevel;

                        if (dotariaPlayer.AcquiredAbilities[ability].Cooldown > 0)
                            abilityButton.Seconds = dotariaPlayer.AcquiredAbilities[ability].Cooldown / DoTariaMath.TICKS_PER_SECOND + 1;
                        else
                            abilityButton.Seconds = 0;

                        abilityButton.SetVisibility(COOLDOWN_VISIBILITY, COOLDOWN_VISIBILITY);
                    }

                    else
                        abilityButton.SetVisibility(ACTIVE_VISIBILITY, INACTIVE_VISIBILITY);
                }

                if (upgradeButton == null)
                    continue;

                bool shouldDisplay = dotariaPlayer.HasSpareLevels && ability.CanUnlock(dotariaPlayer) && (!dotariaPlayer.HasAbility(ability) || ability.InternalCanLevelUp(dotariaPlayer));
                ChangeUpgradeButton(upgradeButton, shouldDisplay);
            }
            
        }

        private void OnAbilityUpgradeButtonClicked(UIMouseEvent evt, UIElement element)
        {
            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(Main.LocalPlayer);
            UIAbilityButton upgradeButton = element as UIAbilityButton;

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

        private void ChangeUpgradeButton(UIAbilityButton button, bool visible)
        {
            button.Width = visible ? _abilityButtonsForUpgradeButtons[button].Width : StyleDimension.Empty;
            button.Height = visible ? new StyleDimension(_upgradeButton.Height, 0f) : StyleDimension.Empty;
            button.SetVisibility(visible ? 1f : 0f, visible ? 0.75f : 0f);
        }


        private UIAbilityButton GetAbilityButtonForAbility(AbilityDefinition ability)
        {
            if (!_abilityButtonsForAbilityDefinitions.ContainsKey(ability))
                return null;

            return _abilityButtonsForAbilityDefinitions[ability];
        }

        private UIAbilityButton GetUpgradeButtonForAbility(AbilityDefinition ability)
        {
            UIAbilityButton abilityButton = GetAbilityButtonForAbility(ability);

            if (abilityButton == null || !_upgradeButtonsForAbilityButtons.ContainsKey(abilityButton))
                return null;

            return _upgradeButtonsForAbilityButtons[abilityButton];
        }


        /*private UIImage[] GetLeveledImagesForDefinition(AbilityDefinition definition)
        {
            if (!_abilityButtonsForAbilityDefinitions.ContainsKey(definition))
                return null;

            return _leveledTextPerAbilityButtons[_abilityButtonsForAbilityDefinitions[definition]];
        }*/

        public Mod Mod { get; }
    }
}