using DoTaria.Heroes.ShadowFiend.Abilities;
using DoTaria.Managers;

namespace DoTaria.Abilities
{
    public sealed class AbilityDefinitionManager : SingletonManager<AbilityDefinitionManager, AbilityDefinition>
    {
        internal override void DefaultInitialize()
        {
            Necromastery = Add(new NecromasteryAbility()) as NecromasteryAbility;

            base.DefaultInitialize();
        }

        #region Shadow Fiend

        public NecromasteryAbility Necromastery { get; private set; }

        #endregion
    }
}
