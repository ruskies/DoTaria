using DoTaria.Players;
using Terraria;
using Terraria.ID;

namespace DoTaria.Leveling.Rules.NPCs
{
    public class EoWBoCNPCLevelingRule : CompositeNPCLevelingRule
    {
        public EoWBoCNPCLevelingRule() : base("EaterofWorlds/BrainofCthulhu", 2, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsBody, NPCID.EaterofWorldsTail)
        {
        }


        public override bool CanExecuteRule(DoTariaPlayer dotariaPlayer, NPC npc, bool executedBefore)
        {
            if (executedBefore)
                return false;

            if (npc.type == NPCID.BrainofCthulhu)
                return true;

            return base.CanExecuteRule(dotariaPlayer, npc, executedBefore);
        }
    }
}