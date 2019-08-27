using System;
using System.Collections.Generic;
using System.Text;
using DoTaria.Abilities;
using DoTaria.Extensions;
using DoTaria.Players;

namespace DoTaria.Helpers
{
    public static class AbilitiesHelper
    {
        public static string SerializeAbilities(params PlayerAbility[] abilities)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < abilities.Length; i++)
            {
                sb.Append(abilities[i].Ability.UnlocalizedName).Append(':').Append(abilities[i].Level).Append(':').Append(abilities[i].Cooldown);

                if (i + 1 < abilities.Length)
                    sb.Append(",");
            }

            return sb.ToString();
        }

        public static PlayerAbility[] DeserializeAbilities(string serializedAbilities)
        {
            string[] splitAbilities = serializedAbilities.Split(',');
            PlayerAbility[] abilities = new PlayerAbility[splitAbilities.Length];

            for (int i = 0; i < splitAbilities.Length; i++)
            {
                string[] unparsedAbility = splitAbilities[i].Split(':');
                abilities[i] = new PlayerAbility(AbilityDefinitionManager.Instance[unparsedAbility[0]], int.Parse(unparsedAbility[1]), int.Parse(unparsedAbility[2]));
            }

            return abilities;
        }


        public static List<float> GetDifferentValues(Func<DoTariaPlayer, PlayerAbility, float> informationGetter, DoTariaPlayer dotariaPlayer, AbilityDefinition ability)
        {
            List<float> differentValues = new List<float>();

            for (int i = 1; i <= ability.MaxLevel; i++)
            {
                float value = informationGetter(dotariaPlayer, new PlayerAbility(ability, i, 0));

                if (!differentValues.Contains(value))
                    differentValues.Add(value);
            }

            return differentValues;
        }

        public static float[] GetAllValues(Func<DoTariaPlayer, PlayerAbility, float> informationGetter, DoTariaPlayer dotariaPlayer, AbilityDefinition ability)
        {
            float[] values = new float[ability.MaxLevel];

            for (int i = 1; i <= ability.MaxLevel; i++)
                values[i - 1] = informationGetter(dotariaPlayer, new PlayerAbility(ability, i, 0));

            return values;
        }


        public static string GenerateCleanSlashedString(float[] values, List<float> differentValues)
        {
            if (differentValues.Count == 1)
                return differentValues[0].ToString();

            return values.GenerateSlashedString();
        }


        public static string GenerateCleanSlashedString(Func<DoTariaPlayer, PlayerAbility, float> informationGetter, DoTariaPlayer dotariaPlayer, AbilityDefinition ability) =>
            GenerateCleanSlashedString(GetAllValues(informationGetter, dotariaPlayer, ability), GetDifferentValues(informationGetter, dotariaPlayer, ability));
    }
}