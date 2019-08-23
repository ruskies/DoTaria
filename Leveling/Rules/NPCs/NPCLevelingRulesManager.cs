using System.Collections.Generic;
using DoTaria.Managers;
using Terraria.ID;

namespace DoTaria.Leveling.Rules.NPCs
{
    public sealed class NPCLevelingRulesManager : SingletonManager<NPCLevelingRulesManager, NPCLevelingRule>
    {
        private readonly Dictionary<int, NPCLevelingRule> _byNPCType = new Dictionary<int, NPCLevelingRule>();


        internal override void DefaultInitialize()
        {
            Add(new StandardNPCLevelingRule(nameof(NPCID.KingSlime), NPCID.KingSlime, 1));
            Add(new StandardNPCLevelingRule(nameof(NPCID.EyeofCthulhu), NPCID.EyeofCthulhu, 1));
            Add(new StandardNPCLevelingRule(nameof(NPCID.QueenBee), NPCID.QueenBee, 1));
            Add(new StandardNPCLevelingRule(nameof(NPCID.SkeletronHead), NPCID.SkeletronHead, 1));
            Add(new StandardNPCLevelingRule(nameof(NPCID.WallofFlesh), NPCID.WallofFlesh, 2));

            Add(new StandardNPCLevelingRule(nameof(NPCID.SkeletronPrime), NPCID.SkeletronPrime, 1));
            Add(new StandardNPCLevelingRule(nameof(NPCID.Plantera), NPCID.Plantera, 1));
            Add(new StandardNPCLevelingRule(nameof(NPCID.Golem), NPCID.Golem, 2));
            Add(new StandardNPCLevelingRule(nameof(NPCID.CultistBoss), NPCID.CultistBoss, 1));
            Add(new StandardNPCLevelingRule(nameof(NPCID.MoonLordCore), NPCID.MoonLordCore, 2));

            base.DefaultInitialize();
        }


        public override NPCLevelingRule Add(NPCLevelingRule item)
        {
            LevelingRuleManager.Instance.Add(item);

            return base.Add(item);
        }

        internal override void Clear()
        {
            _byNPCType.Clear();

            base.Clear();
        }
    }
}