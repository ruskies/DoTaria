using System;
using System.Collections.Generic;
using DoTaria.Commons;
using DoTaria.Enums;
using DoTaria.Extensions;
using DoTaria.Helpers;
using DoTaria.Players;
using DoTaria.Statistic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace DoTaria.Abilities
{
    public abstract class AbilityDefinition : IHasUnlocalizedName
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unlocalizedName"></param>
        /// <param name="displayName"></param>
        /// <param name="abilityType"></param>
        /// <param name="abilityTargetType"></param>
        /// <param name="abilityTargetUnitFaction"></param>
        /// <param name="damageType"></param>
        /// <param name="abilitySlot"></param>
        /// <param name="unlockableAtLevel">At what level can the player start leveling this ability. A level of 0 means the player starts with the ability.</param>
        /// <param name="maxLevel">The maximum level that this ability can be leveled up to.</param>
        /// <param name="alwaysShowInAbilitesBar"></param>
        /// <param name="baseCastRange">The maximum distance between the target point and the player.</param>
        /// <param name="affectsTotalAbilityLevelCount">Should this ability contribute towards the total levels spent on abilities count.</param>
        protected AbilityDefinition(string unlocalizedName, string displayName, AbilityType abilityType, AbilityTargetType abilityTargetType, AbilityTargetFaction abilityTargetUnitFaction, AbilityTargetUnitType abilityTargetUnitType, DamageType damageType, AbilitySlot abilitySlot, int unlockableAtLevel, int maxLevel, bool alwaysShowInAbilitesBar = true, float baseCastRange = -1, bool affectsTotalAbilityLevelCount = true)
        {
            UnlocalizedName = unlocalizedName;
            DisplayName = displayName;

            AbilityType = abilityType;
            AbilityTargetType = abilityTargetType;
            AbilityTargetUnitFaction = abilityTargetUnitFaction;
            AbilityTargetUnitType = abilityTargetUnitType;

            DamageType = damageType;

            AbilitySlot = abilitySlot;

            UnlockableAtLevel = unlockableAtLevel;
            MaxLevel = maxLevel;

            AlwaysShowInAbilitiesBar = alwaysShowInAbilitesBar;

            BaseCastRange = baseCastRange;
            AffectsTotalAbilityLevelCount = affectsTotalAbilityLevelCount;
        }


        public virtual void OnAbilityCasted(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) { }


        public bool InternalCanCastAbility(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility)
        {
            if (AbilityType == AbilityType.Passive && AbilityType != AbilityType.Active)
                return false;

            if (!CanCastAbility(dotariaPlayer, playerAbility))
                return false;

            if (AbilityTargetType != AbilityTargetType.TargetUnit)
                return true;

            if (AbilityTargetUnitType == AbilityTargetUnitType.Living)
            {
                if (AbilityTargetUnitType == AbilityTargetUnitType.Living)
                {
                    EntitiesHelper.GetLocalHoveredEntity(out Player player, out NPC npc);

                    return player != null || npc != null;
                }

                if (AbilityTargetUnitType == AbilityTargetUnitType.Heroes)
                    return EntitiesHelper.GetLocalHoveredPlayer() != null;

                if (AbilityTargetUnitType == AbilityTargetUnitType.Units)
                    return EntitiesHelper.GetLocalHoveredNPC() != null;
            }

            return true;
        }

        public virtual bool CanCastAbility(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => true;


        public bool InternalCastAbility(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, bool casterIsLocalPlayer)
        {
            float calculatedDamage = InternalGetAbilityDamage(dotariaPlayer, playerAbility);

            if (CastAbility(dotariaPlayer, playerAbility, casterIsLocalPlayer, calculatedDamage))
            {
                playerAbility.Cooldown = playerAbility.Ability.InternalGetCooldown(dotariaPlayer) * DoTariaMath.TICKS_PER_SECOND;
                return true;
            }

            return false;
        }

        public virtual bool CastAbility(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, bool casterIsLocalPlayer, float calculatedDamage) => true;


        public virtual bool CanUnlock(DoTariaPlayer dotariaPlayer) => dotariaPlayer.Level != -1 && dotariaPlayer.Level >= UnlockableAtLevel;

        public int InternalGetCooldown(DoTariaPlayer dotariaPlayer) => (int)InternalGetCooldown(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]);
        public int InternalGetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => (int)Math.Ceiling(GetCooldown(dotariaPlayer, playerAbility));
        public abstract float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility);
        

        public float InternalGetManaCost(DoTariaPlayer dotariaPlayer) => InternalGetManaCost(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]);
        public float InternalGetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility)
        {
            float manacost = GetManaCost(dotariaPlayer, playerAbility);

            return manacost < 0 ? 0 : manacost;
        }

        public abstract float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility);


        public float InternalGetAbilityDamage(DoTariaPlayer dotariaPlayer) => InternalGetAbilityDamage(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]);
        public float InternalGetAbilityDamage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => GetAbilityDamage(dotariaPlayer, playerAbility) * dotariaPlayer.SpellAmplification;
        public virtual float GetAbilityDamage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;


        public float InternalGetCastRange(DoTariaPlayer dotariaPlayer) => InternalGetCastRange(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]);
        public float InternalGetCastRange(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => GetCastRange(dotariaPlayer, playerAbility);
        public virtual float GetCastRange(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => BaseCastRange;


        internal bool InternalCanLevelUp(DoTariaPlayer dotariaPlayer) =>
            CanLevelUp(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]) && dotariaPlayer.Level >= InternalGetRequiredLevelForNextUpgrade(dotariaPlayer) && (!dotariaPlayer.HasAbility(this) || dotariaPlayer.AcquiredAbilities[this].Level < MaxLevel);

        public virtual bool CanLevelUp(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => playerAbility.Level + 1 < dotariaPlayer.Level;

        public int InternalGetRequiredLevelForNextUpgrade(DoTariaPlayer dotariaPlayer) => GetRequiredLevelForNextUpgrade(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]);

        public virtual int GetRequiredLevelForNextUpgrade(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility)
        {
            if (AbilitySlot == AbilitySlot.Ultimate)
                return (playerAbility.Level + 1) * 6;

            return (playerAbility.Level * 2) + 1;
        }

        public void InternalOnAbilityLeveledUp(DoTariaPlayer dotariaPlayer) => OnAbilityLeveledUp(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]);
        public virtual void OnAbilityLeveledUp(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) { }


        public void InternalOnAbilityCooldownExpired(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            OnAbilityCooldownExpired(dotariaPlayer, playerAbility);

        public virtual void OnAbilityCooldownExpired(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            dotariaPlayer.TryActivateAbility(this);


        #region Player Hooks

        public virtual void OnPlayerHitNPCWithItem(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, NPC npc, Player player, Item item, int damage, float knockback, bool crit) { }
        public virtual void OnPlayerHitNPCWithProjectile(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, NPC npc, Projectile projectile, int damage, float knockback, bool crit) { }

        public virtual void OnPlayerKilledNPC(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, NPC npc) { }

        public virtual void ModifyPlayerDrawLayers(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, List<PlayerLayer> layers) { }

        public virtual void ModifyWeaponDamage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, Item item, ref float add, ref float mult, ref float flat) { }


        public virtual bool OnPlayerPreHurt(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) => true;
        public virtual void OnPlayerPostHurt(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, bool pvp, bool quiet, double damage, int hitDirection, bool crit) { }


        public virtual void OnPlayerPreUpdate(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) { }
        public virtual void OnPlayerPreUpdateMovement(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) { }

        #endregion


        public string UnlocalizedName { get; }
        public string DisplayName { get; }

        public AbilityType AbilityType { get; }
        public AbilityTargetType AbilityTargetType { get; }
        public AbilityTargetFaction AbilityTargetUnitFaction { get; }
        public AbilityTargetUnitType AbilityTargetUnitType { get; }

        public DamageType DamageType { get; }

        public AbilitySlot AbilitySlot { get; }

        public int UnlockableAtLevel { get; }
        public int MaxLevel { get; }

        public bool AlwaysShowInAbilitiesBar { get; }

        public float BaseCastRange { get; }

        public bool AffectsTotalAbilityLevelCount { get; }

        public Texture2D Icon => this.GetType().GetTexture();
    }
}