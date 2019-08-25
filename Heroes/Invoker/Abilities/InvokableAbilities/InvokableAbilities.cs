using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DoTaria.Heroes.Invoker.Abilities.InvokableAbilities
{
    public static class InvokableAbilities
    {
        private static readonly List<InvokableAbility> _loadedInvokableAbilities = new List<InvokableAbility>();


        public static void Load()
        {
            //foreach (TypeInfo typeInfo in DoTariaMod.Instance.Code.DefinedTypes.Where(t => t.IsSubclassOf(typeof(InvokeAbility))))
        }

        public static void Unload()
        {

        }
    }
}