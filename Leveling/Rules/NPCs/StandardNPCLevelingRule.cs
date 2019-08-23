using DoTaria.Players;
using Terraria;

namespace DoTaria.Leveling.Rules.NPCs
{
    public class StandardNPCLevelingRule : NPCLevelingRule
    {
        public StandardNPCLevelingRule(string unlocalizedName, int levels, int npcType) : base(unlocalizedName, levels)
        {
            NPCType = npcType;
        }


        public override bool CanExecuteRule(DoTariaPlayer dotariaPlayer, NPC npc, bool executedBefore) => !executedBefore && npc.type == NPCType;


        public int NPCType { get; }
    }
}