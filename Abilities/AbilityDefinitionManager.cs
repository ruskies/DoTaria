using DoTaria.Heroes.Abaddon.Abilities;
using DoTaria.Heroes.ShadowFiend.Abilities;
using DoTaria.Managers;

namespace DoTaria.Abilities
{
    public sealed class AbilityDefinitionManager : SingletonManager<AbilityDefinitionManager, AbilityDefinition>
    {
        internal override void DefaultInitialize()
        {
            #region Abaddon

            BorrowedTime = Add(new BorrowedTimeAbility()) as BorrowedTimeAbility;

            #endregion

            #region Shadow Fiend

            Necromastery = Add(new NecromasteryAbility()) as NecromasteryAbility;

            #endregion

            base.DefaultInitialize();
        }

        #region Abaddon

        public BorrowedTimeAbility BorrowedTime { get; private set; }

        #endregion

        #region Shadow Fiend

        public NecromasteryAbility Necromastery { get; private set; }

        #endregion
    }
}
