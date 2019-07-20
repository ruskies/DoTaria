using DoTaria.Heroes.ShadowFiend;
using DoTaria.Managers;
using Terraria.DataStructures;

namespace DoTaria.Heroes
{
    public sealed class HeroDefinitionManager : SingletonManager<HeroDefinitionManager, HeroDefinition>
    {
        internal override void DefaultInitialize()
        {
            ShadowFiend = Add(new ShadowFiendHero()) as ShadowFiendHero;

            base.DefaultInitialize();
        }

        
        public ShadowFiendHero ShadowFiend { get; private set; }
    }
}
