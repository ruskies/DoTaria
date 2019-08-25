using System;
using System.Collections.Generic;
using DoTaria.Heroes.Invoker.Abilities.Elements;
using Terraria.ModLoader.IO;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer
    {
        internal readonly List<InvokerElementAbility> currentInvokerElements = new List<InvokerElementAbility>();


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
            currentInvokerElements.Clear();
        }


        public IReadOnlyList<InvokerElementAbility> CurrentElements => currentInvokerElements.AsReadOnly();
    }
}
