using System.Collections.Generic;
using DoTaria.Abilities;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private void SaveAbilities(TagCompound tag)
        {
            Dictionary<string, int> abilityLevelByNames = new Dictionary<string, int>();

            foreach (KeyValuePair<AbilityDefinition, int> kvp in _abilityLevels)

        }

        private void LoadAbilities(TagCompound tag)
        {

        }
    }
}
