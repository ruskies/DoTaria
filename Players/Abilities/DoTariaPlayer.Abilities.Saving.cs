using System.Collections.Generic;
using DoTaria.Abilities;
using DoTaria.Heroes;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private void SaveAbilities(TagCompound tag)
        {
            List<string> abilitiesInformation = new List<string>();

            foreach (KeyValuePair<AbilityDefinition, PlayerAbility> kvp in AcquiredAbilities)
                abilitiesInformation.Add(kvp.Key.UnlocalizedName + '|' + kvp.Value.Level + ':' + kvp.Value.Cooldown);

            tag.Add(nameof(AcquiredAbilities), abilitiesInformation);
        }

        private void LoadAbilities(TagCompound tag)
        {
            AcquiredAbilities.Clear();

            IList<string> abilitiesInformationUnparsed = tag.GetList<string>(nameof(AcquiredAbilities));

            for (int i = 0; i < abilitiesInformationUnparsed.Count; i++)
            {
                string[] splitInformation = abilitiesInformationUnparsed[i].Split('|');
                string[] splitAbilityInformation = splitInformation[1].Split(':');

                AbilityDefinition ability = AbilityDefinitionManager.Instance[splitInformation[0]];
                AcquiredAbilities.Add(ability, new PlayerAbility(ability, int.Parse(splitAbilityInformation[0]), int.Parse(splitAbilityInformation[1])));
            }

            foreach (AbilityDefinition ability in Hero.Abilities)
                if (ability.UnlockableAtLevel == 0 && !HasAbility(ability))
                    AcquireOrLevelUp(ability); // TODO Add a way to verify this.
        }
    }
}
