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
            Add(new StandardNPCLevelingRule(nameof(NPCID.KingSlime), 1, NPCID.KingSlime));
            Add(new StandardNPCLevelingRule(nameof(NPCID.EyeofCthulhu), 1, NPCID.EyeofCthulhu));
            Add(new EoWBoCNPCLevelingRule());
            Add(new StandardNPCLevelingRule(nameof(NPCID.QueenBee), 1, NPCID.QueenBee));
            Add(new StandardNPCLevelingRule(nameof(NPCID.SkeletronHead), 1, NPCID.SkeletronHead));
            Add(new StandardNPCLevelingRule(nameof(NPCID.WallofFlesh), 2, NPCID.WallofFlesh));

            Add(new CompositeNPCLevelingRule("TheTwins", 1, NPCID.Retinazer, NPCID.Spazmatism));
            Add(new StandardNPCLevelingRule(nameof(NPCID.TheDestroyer), 1, NPCID.TheDestroyer));
            Add(new StandardNPCLevelingRule(nameof(NPCID.SkeletronPrime), 1, NPCID.SkeletronPrime));
            Add(new StandardNPCLevelingRule(nameof(NPCID.Plantera), 1, NPCID.Plantera));
            Add(new StandardNPCLevelingRule(nameof(NPCID.Golem), 2, NPCID.Golem));
            Add(new StandardNPCLevelingRule(nameof(NPCID.DukeFishron), 1, NPCID.DukeFishron));
            Add(new StandardNPCLevelingRule(nameof(NPCID.CultistBoss), 1, NPCID.CultistBoss));

            Add(new StandardNPCLevelingRule(nameof(NPCID.MoonLordCore), 2, NPCID.MoonLordCore));

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