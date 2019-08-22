using System;
using System.Collections.Generic;
using System.Linq;
using DoTaria.Leveling.Rules;
using DoTaria.Leveling.Rules.NPCs;
using DoTaria.Network;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private List<string> _executedLevelingRuleNames = new List<string>();


        public void OnKilledNPCLevels(NPC npc)
        {
            NPCLevelingRulesManager.Instance.ForAllItems(nlr =>
            {
                if (nlr.CanExecuteRule(this, npc, _executedLevelingRuleNames.Any(n => n.Equals(nlr.UnlocalizedName, StringComparison.CurrentCultureIgnoreCase))))
                {
                    _executedLevelingRuleNames.Add(nlr.UnlocalizedName); // We store the name so that even if a player removes a mod, the leveling rule will still be saved.
                    LevelUp(nlr.Levels);
                }
            });
        }

        public void LevelUp(int levels)
        {
            Level += levels;

            if (Main.netMode == NetmodeID.MultiplayerClient)
                NetworkPacketManager.Instance.PlayerLeveledUp.SendPacketToServer(player.whoAmI, player.whoAmI, levels);
        }


        public int Level { get; set; } = 1;

        public IReadOnlyList<LevelingRule> ExecutedLevelingRules => LevelingRuleManager.Instance.Where(lr => _executedLevelingRuleNames.Any(lrn => lrn.Equals(lr.UnlocalizedName, StringComparison.CurrentCultureIgnoreCase))).AsReadOnly();
        public IReadOnlyList<string> ExecutedNPCLevelingRuleNames => _executedLevelingRuleNames.AsReadOnly();
    }
}
