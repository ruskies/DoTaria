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
            DamageType damageType, InvokerElementAbility[] requiredElements, float baseCastRange = -1) : 

            base(UNLOCALIZED_NAME_PREFIX + unlocalizedName, displayName, 
                abilityType, abilityTargetType, abilityTargetUnitFaction, abilityTargetUnitType, 
                damageType, AbilitySlot.Optional, 
                0, 1, false, baseCastRange, false)
        {
            RequiredElements = requiredElements;
        }


        public bool DoesPlayerHaveRequiredElements(DoTariaPlayer dotariaPlayer)
        {
            List<InvokerElementAbility> elements = new List<InvokerElementAbility>(dotariaPlayer.CurrentElements);

            for (int i = 0; i < RequiredElements.Length; i++)
                elements.Remove(RequiredElements[i]);

            return elements.Count == 0;
        }
        

        public InvokerElementAbility[] RequiredElements { get; }
    }
}