using System.Collections.Generic;
using DoTaria.Managers;
using Terraria.ID;

namespace DoTaria.Leveling.Rules.Invasions
{
    public sealed class InvasionLevelingRuleManager : SingletonManager<InvasionLevelingRuleManager, InvasionLevelingRule>
    {
        private readonly Dictionary<int, InvasionLevelingRule> _byId = new Dictionary<int, InvasionLevelingRule>();


        internal override void DefaultInitialize()
        {
            Add(InvasionID.GoblinArmy, new StandardInvasionLevelingRule(nameof(InvasionID.GoblinArmy), 1, InvasionID.GoblinArmy));

            Add(InvasionID.PirateInvasion, new StandardInvasionLevelingRule(nameof(InvasionID.PirateInvasion), 1, InvasionID.PirateInvasion));
            Add(InvasionID.MartianMadness, new StandardInvasionLevelingRule(nameof(InvasionID.MartianMadness), 1, InvasionID.MartianMadness));

            Add(InvasionID.CachedFrostMoon, new StandardInvasionLevelingRule(nameof(InvasionID.CachedFrostMoon), 1, InvasionID.CachedFrostMoon));
            Add(InvasionID.CachedPumpkinMoon, new StandardInvasionLevelingRule(nameof(InvasionID.CachedPumpkinMoon), 1, InvasionID.CachedPumpkinMoon));

            base.DefaultInitialize();
        }


        public InvasionLevelingRule Add(int invasionId, InvasionLevelingRule item)
        {
            InvasionLevelingRule rule = Add(item);
            LevelingRuleManager.Instance.Add(rule);

            if (!_byId.ContainsKey(invasionId))
                _byId.Add(invasionId, item);

            return rule;
        }

        public InvasionLevelingRule Get(int invasionId) => _byId.ContainsKey(invasionId) ? _byId[invasionId] : null;

        internal override void Clear()
        {
            _byId.Clear();

            base.Clear();
        }
    }
}