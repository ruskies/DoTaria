namespace DoTaria.Attribute
{
    public class Attributes
    {
        private const float
            HEALTH_PER_STRENGTH = 20,
            HEALTH_REGENERATION_PER_STRENGTH = 0.1f,
            MAGIC_RESISTANCE_PER_STRENGTH = 0.0008f,

            ARMOR_PER_AGILITY = 0.16f,
            ATTACK_SPEED_PER_AGILITY = 1,
            MOVEMENT_SPEED_PER_AGILITY = 0.0005f,

            MAXIMUM_MANA_PER_INTELLIGENCE = 12,
            MANA_REGENERATION_PER_INTELLIGENCE = 0.05f,
            SPELL_DAMAGE_PER_INTELLIGENCE = 0.0007f;

        public Attributes(float strength, float agility, float intelligence)
        {
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
        }


        public float StrengthToHealth() => HealthFromStrength(Strength);
        public float StrengthToHealthRegeneration() => HealthRegenerationFromStrength(Strength);

        public float ToArmor() => MagicRegistanceFromStrength(Strength) + ArmorFromAgility(Strength);
        public float StrengthToMagicResistance() => MagicRegistanceFromStrength(Strength);
        public float AgilityToArmor() => ArmorFromAgility(Agility);

        public float AgilityToAttackSpeed() => AttackSpeedFromAgility(Agility);
        public float AgilityToMovementSpeed() => MovementSpeedPerAgility(Agility);

        public float IntelligenceToMaximumMana() => MaximumManaFromIntelligence(Intelligence);
        public float IntelligenceToManaRegeneration() => ManaRegenerationFromIntelligence(Intelligence);
        public float IntelligenceToSpellDamage() => SpellDamageFromIntelligence(Intelligence);

        public float Strength { get; set; }
        public float Agility { get; set; }
        public float Intelligence { get; set; }

        public static float HealthFromStrength(float strength) => strength * HEALTH_PER_STRENGTH;
        public static float HealthRegenerationFromStrength(float strength) => strength * HEALTH_REGENERATION_PER_STRENGTH;
        public static float MagicRegistanceFromStrength(float strength) => strength * MAGIC_RESISTANCE_PER_STRENGTH;

        public static float ArmorFromAgility(float agility) => agility * ARMOR_PER_AGILITY;
        public static float AttackSpeedFromAgility(float agility) => agility * ATTACK_SPEED_PER_AGILITY;
        public static float MovementSpeedPerAgility(float agility) => agility * MOVEMENT_SPEED_PER_AGILITY;

        public static float MaximumManaFromIntelligence(float intelligence) => intelligence * MAXIMUM_MANA_PER_INTELLIGENCE;
        public static float ManaRegenerationFromIntelligence(float intelligence) => intelligence * MANA_REGENERATION_PER_INTELLIGENCE;
        public static float SpellDamageFromIntelligence(float intelligence) => intelligence * SPELL_DAMAGE_PER_INTELLIGENCE;
    }
}