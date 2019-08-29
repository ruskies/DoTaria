using System;
using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Helpers;
using DoTaria.Heroes.Invoker.Abilities.Elements;
using DoTaria.Players;

namespace DoTaria.Heroes.Invoker.Abilities.InvokableAbilities
{
    public class ColdSnapAbility : InvokableAbility
    {
        public ColdSnapAbility() : base("coldSnap", "Cold Snap", 
            AbilityType.Active, AbilityTargetType.TargetUnit, AbilityTargetFaction.Enemies, AbilityTargetUnitType.Living, DamageType.Magical, 1000)
        {
        }

        public override string GetAbilityTooltip(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            "Invoker draws the heat from an enemy, chilling them to their very core for a duration based on the level of Quas. The enemy will take damage and be briefly frozen. Further damage taken in this state will freeze the enemy again, dealing bonus damage. The enemy can only be frozen so often, but the freeze cooldown decreases based on the level of Quas.\n\n" +
            $"Cold snap duration (quas):\n{AbilitiesHelper.GenerateCleanSlashedString(GetColdSnapDuration, dotariaPlayer, AbilityDefinitionManager.Instance.Quas)}\n" + 
            $"Freeze duration: {AbilitiesHelper.GenerateCleanSlashedString(GetFreezeDuration, dotariaPlayer, this)}\n" + 
            $"Freeze cooldown (quas):\n{AbilitiesHelper.GenerateCleanSlashedString(GetFreezeCooldown, dotariaPlayer, AbilityDefinitionManager.Instance.Quas)}\n" + 
            $"Freeze damage (quas):\n{AbilitiesHelper.GenerateCleanSlashedString(GetFreezeDamage, dotariaPlayer, AbilityDefinitionManager.Instance.Quas)}";


        public static float GetColdSnapDuration(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 
            2.5f + (playerAbility.Level + (dotariaPlayer.HasAghanims() ? 1 : 0)) * 0.5f;

        public static float GetFreezeDuration(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0.4f;

        public static float GetFreezeCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            0.8f - (playerAbility.Level + (dotariaPlayer.HasAghanims() ? 1 : 0)) * 0.03f;

        public static float GetFreezeDamage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            (playerAbility.Level + (dotariaPlayer.HasAghanims() ? 1 : 0)) * 8;


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 20;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 100;


        public override Func<AbilityDefinitionManager, InvokerElementAbility[]> RequiredElements { get; } = manager => 
            new InvokerElementAbility[] { manager.Quas, manager.Quas, manager.Quas };
    }
}