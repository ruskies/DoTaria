using System;
using DoTaria.Commons;
using DoTaria.Enums;
using DoTaria.Extensions;
using DoTaria.Players;
using DoTaria.Statistic;
using Microsoft.Xna.Framework.Graphics;

namespace DoTaria.Abilities
{
    public abstract class AbilityDefinition : IHasUnlocalizedName
    {
        protected AbilityDefinition(string unlocalizedName, string displayName, AbilityType abilityType, DamageType damageType, AbilitySlot abilitySlot, int unlockableAtLevel, int maxLevel, bool alwaysShowInAbilitesBar = true)
        {
            UnlocalizedName = unlocalizedName;
            DisplayName = displayName;

            AbilityType = abilityType;
            DamageType = damageType;

            AbilitySlot = abilitySlot;

            UnlockableAtLevel = unlockableAtLevel;
            MaxLevel = maxLevel;

            AlwaysShowInAbilitiesBar = alwaysShowInAbilitesBar;
        }


        public virtual void OnAbilityCasted(DoTariaPlayer dotariaPlayer) { }


        internal bool InternalCastAbility(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility)
        {
            if (CastAbility(dotariaPlayer, playerAbility))
            {
                playerAbility.Cooldown = playerAbility.Ability.InternalGetCooldown(dotariaPlayer) * DoTariaMath.TICKS_PER_SECOND;
                return true;
            }

            return false;
        }

        public virtual bool CastAbility(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility)
        {
            return false;
        }


        public virtual bool CanUnlock(DoTariaPlayer dotariaPlayer) => dotariaPlayer.Level != -1 && dotariaPlayer.Level >= UnlockableAtLevel;

        internal int InternalGetCooldown(DoTariaPlayer dotariaPlayer) => (int) Math.Ceiling(GetCooldown(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]));
        public abstract float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility);

        internal float InternalGetManaCost(DoTariaPlayer dotariaPlayer) => GetManaCost(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]) * Statistics.TERRARIA_MANA_RATIO;
        public abstract float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility);


        internal float InternalGetAbilityDamage(DoTariaPlayer dotariaPlayer) => InternalGetAbilityDamage(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]);
        internal float InternalGetAbilityDamage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => GetAbilityDamage(dotariaPlayer, playerAbility) * dotariaPlayer.SpellAmplification;
        public virtual float GetAbilityDamage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;


        internal bool InternalCanLevelUp(DoTariaPlayer dotariaPlayer) => 
            CanLevelUp(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]) && dotariaPlayer.Level >= InternalGetRequiredLevelForNextUpgrade(dotariaPlayer) && (!dotariaPlayer.HasAbility(this) || dotariaPlayer.AcquiredAbilities[this].Level < MaxLevel);

        public virtual bool CanLevelUp(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => playerAbility.Level + 1 < dotariaPlayer.Level;

        internal int InternalGetRequiredLevelForNextUpgrade(DoTariaPlayer dotariaPlayer) => GetRequiredLevelForNextUpgrade(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]);

        public virtual int GetRequiredLevelForNextUpgrade(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility)
        {
            if (AbilitySlot == AbilitySlot.Ultimate)
                return (playerAbility.Level + 1) * 6;

            return (playerAbility.Level * 2) + 1;
        }

        internal void InternalOnAbilityLeveledUp(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => OnAbilityLeveledUp(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]);
        public virtual void OnAbilityLeveledUp(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) { }


        public string UnlocalizedName { get; }
        public string DisplayName { get; }

        public AbilityType AbilityType { get; }
        public DamageType DamageType { get; }

        public AbilitySlot AbilitySlot { get; }

        public int UnlockableAtLevel { get; }
        public int MaxLevel { get; }

        public bool AlwaysShowInAbilitiesBar { get; }

        public Texture2D Icon => this.GetType().GetTexture();
    }
}