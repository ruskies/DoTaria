using DoTarria.Abilities;
using DoTarria.Enums;

namespace DoTarria.Heroes.ShadowFiend.Abilities
{
    public sealed class NecromasteryAbility : AbilityDefinition
    {
        public NecromasteryAbility() : base("shadowFiend.necromastery", "Necromastery", AbilityType.Passive, DamageType.Physical)
        {
        }
    }
}