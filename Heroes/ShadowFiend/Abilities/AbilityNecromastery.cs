using DoTaria.Abilities;
using DoTaria.Enums;

namespace DoTaria.Heroes.ShadowFiend.Abilities
{
    public sealed class AbilityNecromastery : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME_SUFFIX = "necromastery";

        public AbilityNecromastery() : base(HeroShadowFiend.UNLOCALIZED_NAME + '.' + UNLOCALIZED_NAME_SUFFIX, "Necromastery", AbilityType.Passive, DamageType.Physical)
        {
        }
    }
}