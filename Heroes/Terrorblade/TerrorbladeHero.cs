using DoTaria.Abilities;
using DoTaria.Attribute;
using DoTaria.Statistic;

namespace DoTaria.Heroes.Terrorblade
{
    public sealed class TerrorbladeHero : HeroDefinition
    {
        public const string UNLOCALIZED_NAME = UNLOCALIZED_NAME_PREFIX + "terrorblade";


        public TerrorbladeHero() : base(UNLOCALIZED_NAME, "Terrorblade", new Attributes(15, 22, 19), new Attributes(1.7f, 4.8f, 1.6f),
            new Statistics(200, 0, 0.25f, 7, 0.67f, 0, 75, 0, 0),
            310)
        {
        }
    }
}