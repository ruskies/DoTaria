using DoTarria.Heroes.ShadowFiend.Abilities;
using DoTarria.Managers;

namespace DoTarria.Abilities
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
