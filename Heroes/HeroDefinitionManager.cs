﻿using DoTarria.Heroes.ShadowFiend;
using DoTarria.Managers;
using Terraria.DataStructures;

namespace DoTarria.Heroes
{
    public sealed class HeroDefinitionManager : SingletonManager<HeroDefinitionManager, HeroDefinition>
    {
        internal override void DefaultInitialize()
        {
            ShadowFiend = Add(new HeroShadowFiend()) as HeroShadowFiend;

            base.DefaultInitialize();
        }

        
        public HeroShadowFiend ShadowFiend { get; private set; }
    }
}
