using System.Text;
using DoTaria.Abilities;

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
    }
}