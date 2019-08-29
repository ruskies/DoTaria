using System;
using System.Collections.Generic;
using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Heroes.Invoker.Abilities.Elements;
using DoTaria.Players;

namespace DoTaria.Heroes.Invoker.Abilities.InvokableAbilities
{
    public abstract class InvokableAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME_PREFIX = InvokerHero.UNLOCALIZED_NAME + ".";


        protected InvokableAbility(string unlocalizedName, string displayName, 
            AbilityType abilityType, AbilityTargetType abilityTargetType, AbilityTargetFaction abilityTargetUnitFaction, AbilityTargetUnitType abilityTargetUnitType, 
            DamageType damageType, float baseCastRange = -1) : 

            base(UNLOCALIZED_NAME_PREFIX + unlocalizedName, displayName, 
                abilityType, abilityTargetType, abilityTargetUnitFaction, abilityTargetUnitType, 
                damageType, AbilitySlot.Optional, 
                0, 1, false, baseCastRange, false)
        {
        }


        public bool DoesPlayerHaveRequiredElements(DoTariaPlayer dotariaPlayer) => DoesPlayerHaveRequiredElements(new List<InvokerElementAbility>(dotariaPlayer.CurrentElements));

        public bool DoesPlayerHaveRequiredElements(List<InvokerElementAbility> elements)
        {
            List<InvokerElementAbility> clonedElements = new List<InvokerElementAbility>(elements);
            InvokerElementAbility[] invokerElements = RequiredElements(AbilityDefinitionManager.Instance);

            for (int i = 0; i < invokerElements.Length; i++)
                clonedElements.Remove(invokerElements[i]);

            return clonedElements.Count == 0;
        }


        public abstract Func<AbilityDefinitionManager, InvokerElementAbility[]> RequiredElements { get; }
    }
}