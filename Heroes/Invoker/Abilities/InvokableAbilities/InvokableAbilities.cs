using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DoTaria.Abilities;
using DoTaria.Heroes.Invoker.Abilities.Elements;

namespace DoTaria.Heroes.Invoker.Abilities.InvokableAbilities
{
    public static class InvokableAbilities
    {
        private static List<InvokableAbility> _loadedInvokableAbilities;


        public static InvokableAbility GetAbilityForCombination(params InvokerElementAbility[] elements)
        {
            List<InvokerElementAbility> clonedElements = new List<InvokerElementAbility>(elements);

            for (int i = 0; i < _loadedInvokableAbilities.Count; i++)
                if (_loadedInvokableAbilities[i].DoesPlayerHaveRequiredElements(clonedElements))
                    return _loadedInvokableAbilities[i];

            return null;
        }


        public static void Load()
        {
            _loadedInvokableAbilities = new List<InvokableAbility>();

            foreach (TypeInfo typeInfo in DoTariaMod.Instance.Code.DefinedTypes.Where(t => t.IsSubclassOf(typeof(InvokableAbility))))
                _loadedInvokableAbilities.Add(
                    AbilityDefinitionManager.Instance[(Activator.CreateInstance(typeInfo) as InvokableAbility).UnlocalizedName] as InvokableAbility);
        }

        public static void Unload() =>
            _loadedInvokableAbilities = null;
    }
}