using DoTaria.Heroes.Abaddon.Abilities;
using DoTaria.Heroes.Abaddon.Abilities.AphoticShield;
using DoTaria.Heroes.Abaddon.Abilities.BorrowedTime;
using DoTaria.Heroes.Abaddon.Abilities.CurseOfAvernus;
using DoTaria.Heroes.Abaddon.Abilities.MistCoil;
using DoTaria.Heroes.Invoker.Abilities;
using DoTaria.Heroes.Invoker.Abilities.Elements;
using DoTaria.Heroes.Invoker.Abilities.InvokableAbilities;
using DoTaria.Heroes.ShadowFiend.Abilities;
using DoTaria.Heroes.ShadowFiend.Abilities.Necromastery;
using DoTaria.Heroes.ShadowFiend.Abilities.PresenceoftheDarkLord;
using DoTaria.Heroes.ShadowFiend.Abilities.Shadowrazes;
using DoTaria.Managers;

namespace DoTaria.Abilities
{
    public sealed class AbilityDefinitionManager : SingletonManager<AbilityDefinitionManager, AbilityDefinition>
    {
        internal override void DefaultInitialize()
        {
            #region Abaddon

            MistCoil = Add(new MistCoilAbility()) as MistCoilAbility;
            AphoticShield = Add(new AphoticShieldAbility()) as AphoticShieldAbility;
            CurseofAvernus = Add(new CurseofAvernusAbility()) as CurseofAvernusAbility;
            BorrowedTime = Add(new BorrowedTimeAbility()) as BorrowedTimeAbility;

            #endregion

            #region Invoker

            Exort = Add(new ExortAbility()) as ExortAbility;
            Quas = Add(new QuasAbility()) as QuasAbility;
            Wex = Add(new WexAbility()) as WexAbility;

            Invoke = Add(new InvokeAbility()) as InvokeAbility;

            GhostWalk = Add(new GhostWalkAbility()) as GhostWalkAbility;

            #endregion

            #region Shadow Fiend

            Necromastery = Add(new NecromasteryAbility()) as NecromasteryAbility;
            PresenceoftheDarkLord = Add(new PresenceoftheDarkLordAbility()) as PresenceoftheDarkLordAbility;

            RequiemofSouls = Add(new RequiemofSoulsAbility()) as RequiemofSoulsAbility;

            ShadowrazeFar = Add(new ShadowrazeFarAbility()) as ShadowrazeFarAbility;
            ShadowrazeMiddle = Add(new ShadowrazeMiddleAbility()) as ShadowrazeMiddleAbility;
            ShadowrazeNear = Add(new ShadowrazeNearAbility()) as ShadowrazeNearAbility;

            #endregion

            base.DefaultInitialize();
        }

        #region Abaddon

        public MistCoilAbility MistCoil { get; private set; }
        public AphoticShieldAbility AphoticShield { get; private set; }
        public CurseofAvernusAbility CurseofAvernus { get; private set; }
        public BorrowedTimeAbility BorrowedTime { get; private set; }

        #endregion

        #region Invoker

        public ExortAbility Exort { get; private set; }
        public QuasAbility Quas { get; private set; }
        public WexAbility Wex { get; private set; }

        public InvokeAbility Invoke { get; private set; }

        public GhostWalkAbility GhostWalk { get; private set; }

        #endregion

        #region Shadow Fiend

        public NecromasteryAbility Necromastery { get; private set; }
        public PresenceoftheDarkLordAbility PresenceoftheDarkLord { get; private set; }

        public RequiemofSoulsAbility RequiemofSouls { get; private set; }

        public ShadowrazeFarAbility ShadowrazeFar { get; private set; }
        public ShadowrazeMiddleAbility ShadowrazeMiddle { get; private set; }
        public ShadowrazeNearAbility ShadowrazeNear { get; private set; }

        #endregion
    }
}
