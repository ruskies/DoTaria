namespace DoTaria.Abilities
{
    public class PlayerAbility
    {
        public PlayerAbility(AbilityDefinition ability) : this(ability, 0)
        {
        }

        public PlayerAbility(AbilityDefinition ability, int level)
        {
            Ability = ability;
            Level = level;
        }

        public AbilityDefinition Ability { get; }

        public int Level { get; }

        public int Cooldown { get; }
    }
}
