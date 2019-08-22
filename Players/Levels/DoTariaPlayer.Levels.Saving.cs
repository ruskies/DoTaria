using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private void SaveLevels(TagCompound tag)
        {
            tag.Add(nameof(Level), Level);
            tag.Add(nameof(ExecutedNPCLevelingRuleNames), _executedLevelingRuleNames);
        }

        public void LoadLevels(TagCompound tag)
        {
            Level = tag.GetAsInt(nameof(Level));
            _executedLevelingRuleNames = tag.GetList<string>(nameof(ExecutedNPCLevelingRuleNames)) as List<string>;
        }
    }
}
