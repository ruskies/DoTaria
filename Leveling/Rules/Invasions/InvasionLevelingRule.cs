using DoTaria.Players;

namespace DoTaria.Leveling.Rules.Invasions
{
    public abstract class InvasionLevelingRule : LevelingRule
    {
        protected InvasionLevelingRule(string unlocalizedName, int levels) : base(unlocalizedName, levels)
        {
        }


        /// <summary>Rule that defines wether or not the player level from surviving a certain invasion.</summary>
        /// <param name="dotariaPlayer">The player who survived the invasion.</param>
        /// <param name="invasionId">The id of the invasion.</param>
        /// <param name="executedBefore">Was the rule already applied to the player before.</param>
        /// <returns>true to make the player level up; otherwise false.</returns>
        public abstract bool CanExecuteRule(DoTariaPlayer dotariaPlayer, int invasionId, bool executedBefore);
    }
}