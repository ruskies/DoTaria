using System;
using System.Collections.Generic;
using DoTaria.Heroes.Invoker.Abilities.Elements;
using DoTaria.Heroes.Invoker.Abilities.InvokableAbilities;
using Terraria.ModLoader.IO;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer
    {
        internal List<InvokerElementAbility> currentInvokerElements = new List<InvokerElementAbility>();
        internal List<InvokableAbility> currentlyInvokedSpells = new List<InvokableAbility>();

        public void CastInvokerElement(InvokerElementAbility ability)
        {
            if (currentInvokerElements.Count == 3)
                currentInvokerElements.RemoveAt(0);

            currentInvokerElements.Insert(currentInvokerElements.Count, ability);
        }

        public bool HasInvokerElement(InvokerElementAbility ability) => currentInvokerElements.Contains(ability);

        public int CountInvokerElement(InvokerElementAbility ability)
        {
            int count = 0;

            for (int i = 0; i < currentInvokerElements.Count; i++)
                if (currentInvokerElements[i] == ability)
                    count++;

            return count;
        }


        /*public void InvokerInvokeSpell(InvokableAbility invokableAbility)
        {
            int existingIndex = currentlyInvokedSpells.FindIndex(s => s == invokableAbility);

            if (existingIndex != -1)
            {
                if (existingIndex == 0)
                    return; // The spell is already the first in the list, no need to do anything.
                else if (currentlyInvokedSpells.Count >= 2)

            }
        }*/


        private void InitializeInvoker()
        {
            
        }


        public void ForAllCastElements(Action<DoTariaPlayer, InvokerElementAbility> action)
        {
            for (int i = 0; i < currentInvokerElements.Count; i++)
                action(this, currentInvokerElements[i]);
        }


        private void LoadInvoker(TagCompound tag)
        {
            currentInvokerElements = new List<InvokerElementAbility>();
            currentlyInvokedSpells = new List<InvokableAbility>();
        }


        public IReadOnlyList<InvokerElementAbility> CurrentElements => currentInvokerElements.AsReadOnly();
    }
}
