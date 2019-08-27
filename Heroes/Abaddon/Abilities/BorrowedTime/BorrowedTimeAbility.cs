using DoTaria.Abilities;
using DoTaria.Commons;
using DoTaria.Enums;
using DoTaria.Extensions;
using DoTaria.Helpers;
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

        public override string GetAbilityTooltip(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            $"When activated, all damage dealt to you will heal instead of harm. Most negative buffs will also be removed. If the ability is not on cooldown, it will automatically activate if your health falls below {AbilitiesHelper.GenerateCleanSlashedString((player, ability) => GetHealthThreshold(player, ability), dotariaPlayer, this)}.\n\n" +
            $"Health threshold: {AbilitiesHelper.GenerateCleanSlashedString((player, ability) => GetHealthThreshold(player, ability), dotariaPlayer, this)}" + 
            $"Duration: {AbilitiesHelper.GenerateCleanSlashedString((player, ability) => GetDuration(player, ability), dotariaPlayer, this)}";


        public override void OnPlayerPostHurt(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (dotariaPlayer.player.dead || dotariaPlayer.player.statLife / Statistics.TERRARIA_HEALTH_RATIO <= GetHealthThreshold(dotariaPlayer, playerAbility) && !dotariaPlayer.player.HasBuff<BorrowedTimeBuff>())
                dotariaPlayer.player.AddBuff<BorrowedTimeBuff>(GetDuration(dotariaPlayer, playerAbility) * DoTariaMath.TICKS_PER_SECOND);
        }


        public float GetHealthThreshold(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 400 / Statistics.TERRARIA_HEALTH_RATIO;

        public int GetDuration(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 3 + playerAbility.Level + (dotariaPlayer.HasAghanims() ? 1 : 0);


        // TODO Adjust with talent.
        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 60 - playerAbility.Level * 10;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;
    }
}
