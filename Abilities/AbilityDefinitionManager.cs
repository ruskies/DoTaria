using DoTarria.Heroes.ShadowFiend.Abilities;
using DoTarria.Managers;

namespace DoTarria.Abilities
{
    public sealed class AbilityDefinitionManager : SingletonManager<AbilityDefinitionManager, AbilityDefinition>
    {
        internal override void DefaultInitialize()
        {
            Necromastery = Add(new AbilityNecromastery()) as AbilityNecromastery;

            base.DefaultInitialize();
        }

        #region Shadow Fiend

        public AbilityNecromastery Necromastery { get; private set; }

        #endregion
    }
}
