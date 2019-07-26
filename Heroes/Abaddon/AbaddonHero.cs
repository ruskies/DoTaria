using DoTaria.Abilities;
using DoTaria.Attribute;
using DoTaria.Commons;
using DoTaria.Extensions;
using DoTaria.Heroes.Abaddon.Abilities;
using DoTaria.Heroes.Abaddon.Abilities.BorrowedTime;
using DoTaria.Players;
using DoTaria.Statistic;
using Terraria.DataStructures;

namespace DoTaria.Heroes.Abaddon
{
    public sealed class AbaddonHero : HeroDefinition
    {
        public const string UNLOCALIZED_NAME = HeroDefinition.UNLOCALIZED_NAME_PREFIX + "abaddon";

        public AbaddonHero() : base(UNLOCALIZED_NAME, "Abaddon", new Attributes(23, 23, 21), new Attributes(3, 1.5f, 2),
            new Statistics(200, 0, 0.25f, -2, 0.68f, 1, 75, 0, 0),
            325,
            AbilityDefinitionManager.Instance.BorrowedTime)
        {
        }

        public override bool OnPlayerPreHurt(DoTariaPlayer dotariaPlayer, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (dotariaPlayer.player.HasBuff<BorrowedTimeBuff>())
            {
                dotariaPlayer.player.HealEffect(damage);
                dotariaPlayer.player.statLife += damage;
                return false;
            }

            return true;
        }

        public override void OnPlayerPostHurt(DoTariaPlayer dotariaPlayer, bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (dotariaPlayer.player.dead || 
                dotariaPlayer.player.statLife / Statistics.TERRARIA_HEALTH_RATIO > 400 / Statistics.TERRARIA_HEALTH_RATIO ||
                dotariaPlayer.player.HasBuff<BorrowedTimeBuff>())
                return;

            else
                dotariaPlayer.player.AddBuff<BorrowedTimeBuff>(6 * DoTariaMath.TICKS_PER_SECOND);
        }
    }
}
