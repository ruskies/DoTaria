using DoTaria.Abilities;
using DoTaria.Enums;

namespace DoTaria.Heroes.Abaddon.Abilities
{
    public sealed class BorrowedTimeAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = AbaddonHero.UNLOCALIZED_NAME + ".borrowedTime";

        public BorrowedTimeAbility() : base(UNLOCALIZED_NAME, "Borrowed Time", AbilityType.Active, DamageType.None)
        {
        }
    }
}
