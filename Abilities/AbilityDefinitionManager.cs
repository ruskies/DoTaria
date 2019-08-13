﻿using DoTaria.Heroes.Abaddon.Abilities;
using DoTaria.Heroes.Abaddon.Abilities.BorrowedTime;
using DoTaria.Heroes.Invoker.Abilities;
using DoTaria.Heroes.Invoker.Abilities.Elements;
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

            BorrowedTime = Add(new BorrowedTimeAbility()) as BorrowedTimeAbility;

            #endregion

            #region Invoker

            Exort = Add(new ExortAbility()) as ExortAbility;
            Quas = Add(new QuasAbility()) as QuasAbility;
            Wex = Add(new WexAbility()) as WexAbility;

            Invoke = Add(new InvokeAbility()) as InvokeAbility;

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

        public BorrowedTimeAbility BorrowedTime { get; private set; }

        #endregion

        #region Invoker

        public ExortAbility Exort { get; private set; }
        public QuasAbility Quas { get; private set; }
        public WexAbility Wex { get; private set; }

        public InvokeAbility Invoke { get; private set; }

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
