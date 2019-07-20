using DoTaria.Abilities;
using DoTaria.Enums;

namespace DoTaria.Heroes.ShadowFiend.Abilities
{
    public sealed class NecromasteryAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME_SUFFIX = "necromastery";

        public NecromasteryAbility() : base(ShadowFiendHero.UNLOCALIZED_NAME + '.' + UNLOCALIZED_NAME_SUFFIX, "Necromastery", AbilityType.Passive, DamageType.Physical)
        {
        }
    }
}