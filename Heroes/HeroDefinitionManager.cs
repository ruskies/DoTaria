using DoTaria.Heroes.Abaddon;
using DoTaria.Heroes.ShadowFiend;
using DoTaria.Managers;

namespace DoTaria.Heroes
{
    public sealed class HeroDefinitionManager : SingletonManager<HeroDefinitionManager, HeroDefinition>
    {
        internal override void DefaultInitialize()
        {
            Abaddon = Add(new AbaddonHero()) as AbaddonHero;
            ShadowFiend = Add(new ShadowFiendHero()) as ShadowFiendHero;

            for (int i = 0; i < byIndex.Count; i++)
                AverageBaseMovementSpeed += byIndex[i].BaseMovementSpeed;

            AverageBaseMovementSpeed /= byIndex.Count;

            base.DefaultInitialize();
        }


        public AbaddonHero Abaddon { get; private set; }

        public ShadowFiendHero ShadowFiend { get; private set; }


        public float AverageBaseMovementSpeed { get; private set; }
    }
}
