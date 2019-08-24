using DoTaria.Abilities;
using DoTaria.Commons;
using DoTaria.Enums;
using DoTaria.Extensions;
using DoTaria.Players;
using DoTaria.Statistic;

namespace DoTaria.Heroes.Abaddon.Abilities.BorrowedTime
{
    public sealed class BorrowedTimeAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = AbaddonHero.UNLOCALIZED_NAME + ".borrowedTime";

        public BorrowedTimeAbility() : base(UNLOCALIZED_NAME, "Borrowed Time",
            AbilityType.Active, AbilityTargetType.NoTarget, AbilityTargetFaction.Self, AbilityTargetUnitType.None,
            DamageType.None, AbilitySlot.Ultimate, 6, 3)
        {
        }


        public override void OnPlayerPostHurt(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (dotariaPlayer.player.dead || dotariaPlayer.player.statLife / Statistics.TERRARIA_HEALTH_RATIO <= 400 / Statistics.TERRARIA_HEALTH_RATIO && !dotariaPlayer.player.HasBuff<BorrowedTimeBuff>())
                dotariaPlayer.player.AddBuff<BorrowedTimeBuff>(GetDuration(dotariaPlayer, playerAbility) * DoTariaMath.TICKS_PER_SECOND);
        }


        public int GetDuration(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 3 + playerAbility.Level + (dotariaPlayer.HasAghanims() ? 1 : 0);


        // TODO Adjust with talent.
        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 60 - playerAbility.Level * 10;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;
    }
}
