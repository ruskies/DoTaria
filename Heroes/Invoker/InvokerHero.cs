using DoTaria.Attribute;
using DoTaria.Statistic;

namespace DoTaria.Heroes.Invoker
{
    public sealed class InvokerHero : HeroDefinition
    {
        public const string UNLOCALIZED_NAME = HeroDefinition.UNLOCALIZED_NAME_PREFIX + "invoker";

        public InvokerHero() : base(UNLOCALIZED_NAME, "Invoker", new Attributes(18, 14, 14), new Attributes(2.4f, 1.9f, 4.6f),
            new Statistics(200, 0, 0.25f, 0, 0.59f, 0f, 75, 0, 0), 
            280)
        {
            
        }
    }
}
