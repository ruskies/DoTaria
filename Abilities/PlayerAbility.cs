namespace DoTaria.Abilities
{
    public class PlayerAbility
    {
        public PlayerAbility(AbilityDefinition ability) : this(ability, 1, 0)
        {
        }

        public PlayerAbility(AbilityDefinition ability, int level, int cooldown)
        {
            Ability = ability;
            Level = level;

            Cooldown = cooldown;
        }

        public AbilityDefinition Ability { get; }

        public int Level { get; }

        public int Cooldown { get; set; }
    }
}
