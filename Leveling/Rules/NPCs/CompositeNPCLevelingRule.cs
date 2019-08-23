using DoTaria.Players;
using Terraria;

namespace DoTaria.Leveling.Rules.NPCs
{
    public class CompositeNPCLevelingRule : NPCLevelingRule
    {
        public CompositeNPCLevelingRule(string unlocalizedName, int levels, params int[] requiresNPCsToBeDead) : base(unlocalizedName, levels)
        {
            RequiresNPCsToBeDead = requiresNPCsToBeDead;
        }


        public override bool CanExecuteRule(DoTariaPlayer dotariaPlayer, NPC npc, bool executedBefore)
        {
            if (!npc.boss || executedBefore)
                return false;

            bool componentFound = false;

            for (int i = 0; i < RequiresNPCsToBeDead.Length; i++)
                if (RequiresNPCsToBeDead[i] == npc.type)
                {
                    componentFound = true;
                    break;
                }

            if (!componentFound)
                return false;

            bool anyComponentLeftAlive = false;

            for (int i = 0; i < Main.npc.Length; i++)
            {
                for (int j = 0; j < RequiresNPCsToBeDead.Length; j++)
                {
                    NPC jNPC = Main.npc[i];

                    if (jNPC.type == RequiresNPCsToBeDead[j] && jNPC.active && npc != jNPC)
                    {
                        anyComponentLeftAlive = true;
                        break;
                    }
                }

                if (anyComponentLeftAlive)
                    break;
            }

            if (anyComponentLeftAlive)
                return false;

            return true;
        }


        public int[] RequiresNPCsToBeDead { get; }
    }
}