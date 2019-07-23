using DoTaria.Commons;
using DoTaria.Enums;
using DoTaria.Extensions;
using DoTaria.Players;
using Microsoft.Xna.Framework.Graphics;

namespace DoTaria.Abilities
{
    public abstract class AbilityDefinition : IHasUnlocalizedName
    {
        protected AbilityDefinition(string unlocalizedName, string displayName, AbilityType abilityType, DamageType damageType, AbilitySlot abilitySlot, int maxLevel, bool alwaysShowInAbilitesBar = true)
        {
            UnlocalizedName = unlocalizedName;
            DisplayName = displayName;

            AbilityType = abilityType;
            DamageType = damageType;

            AbilitySlot = abilitySlot;

            MaxLevel = maxLevel;

            AlwaysShowInAbilitiesBar = alwaysShowInAbilitesBar;
        }


        internal float InternalGetCooldown(DoTariaPlayer dotariaPlayer) => GetCooldown(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]);
        public abstract float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility);

        internal float InternalGetManaCost(DoTariaPlayer dotariaPlayer) => GetManaCost(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]);
        public abstract float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility);

        internal bool InternalCanLevelUp(DoTariaPlayer dotariaPlayer) => CanLevelUp(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]) && dotariaPlayer.Level >= InternalGetRequiredLevelForNextUpgrade(dotariaPlayer);
        public virtual bool CanLevelUp(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => playerAbility.Level < MaxLevel;

        internal int InternalGetRequiredLevelForNextUpgrade(DoTariaPlayer dotariaPlayer) => GetRequiredLevelForNextUpgrade(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]);
        public virtual int GetRequiredLevelForNextUpgrade(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => (playerAbility.Level + 1) * 6;


        internal virtual void InternalOnAbilityLeveledUp(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => OnAbilityLeveledUp(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]);
        public virtual void OnAbilityLeveledUp(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) { }


        public string UnlocalizedName { get; }
        public string DisplayName { get; }

        public AbilityType AbilityType { get; }
        public DamageType DamageType { get; }

        public AbilitySlot AbilitySlot { get; }

        public int MaxLevel { get; }

        public bool AlwaysShowInAbilitiesBar { get; }

        public Texture2D Icon => this.GetType().GetTexture();
    }
}