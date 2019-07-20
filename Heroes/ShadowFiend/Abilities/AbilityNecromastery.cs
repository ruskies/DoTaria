using DoTarria.Abilities;
using DoTarria.Enums;

namespace DoTarria.Heroes.ShadowFiend.Abilities
{
    public sealed class AbilityNecromastery : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME_SUFFIX = "necromastery";

        public AbilityNecromastery() : base(HeroShadowFiend.UNLOCALIZED_NAME + '.' + UNLOCALIZED_NAME_SUFFIX, "Necromastery", AbilityType.Passive, DamageType.Physical)
        {
        }
    }
}