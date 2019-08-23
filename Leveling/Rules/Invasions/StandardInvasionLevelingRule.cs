using DoTaria.Players;

namespace DoTaria.Leveling.Rules.Invasions
{
    public class StandardInvasionLevelingRule : InvasionLevelingRule
    {
        public StandardInvasionLevelingRule(string unlocalizedName, int levels, int invasionId) : base(unlocalizedName, levels)
        {
            InvasionId = invasionId;
        }

        public override bool CanExecuteRule(DoTariaPlayer dotariaPlayer, int invasionId, bool executedBefore) => !executedBefore && invasionId == InvasionId;


        public int InvasionId { get; }
    }
}