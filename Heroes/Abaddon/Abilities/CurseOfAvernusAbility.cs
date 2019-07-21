using DoTaria.Abilities;
using DoTaria.Enums;

namespace DoTaria.Heroes.Abaddon.Abilities
{
    public sealed class CurseOfAvernusAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = AbaddonHero.UNLOCALIZED_NAME + ".curseOfAvernus";

        public CurseOfAvernusAbility() : base(UNLOCALIZED_NAME, "Curse of Avernus", AbilityType.Passive, DamageType.None)
        {
        }
    }
}