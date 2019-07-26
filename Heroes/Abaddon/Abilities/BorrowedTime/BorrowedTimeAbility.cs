using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.Abaddon.Abilities.BorrowedTime
{
    public sealed class BorrowedTimeAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = AbaddonHero.UNLOCALIZED_NAME + ".borrowedTime";

        public BorrowedTimeAbility() : base(UNLOCALIZED_NAME, "Borrowed Time", AbilityType.Active, DamageType.None, AbilitySlot.Ultimate, 1, 3)
        {
        }


        // TODO Adjust with talent.
        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 60 - playerAbility.Level * 10;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;
    }
}
