using DoTaria.Commons;
using DoTaria.Players;
using Terraria;

namespace DoTaria.Leveling.Rules.NPCs
{
    public abstract class NPCLevelingRule : LevelingRule, IHasUnlocalizedName
    {
        protected NPCLevelingRule(string unlocalizedName, int levels) : base(unlocalizedName)
        {
            Levels = levels;
        }

        /// <summary>Rule that defines wether or not the player level from defeating a certain npc.</summary>
        /// <param name="dotariaPlayer">The player who defeated the boss.</param>
        /// <param name="npc">The defeated npc.</param>
        /// <param name="executedBefore">Was the rule already applied to the player before.</param>
        /// <returns>true to make the player level up; otherwise false.</returns>
        public abstract bool CanExecuteRule(DoTariaPlayer dotariaPlayer, NPC npc, bool executedBefore);


        public int Levels { get; }
    }
}