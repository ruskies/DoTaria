using DoTaria.Attribute;

namespace DoTaria.Statistic
{
    public class Statistics
    {
        public const float 
            TERRARIA_HEALTH_RATIO = 100f / 400,
            TERRARIA_MANA_RATIO = 75f / 200;

        public Statistics(float health, float healthRegeneration, float magicResistance, float armor, float attackSpeed, float moveSpeedAmplification, float mana, float manaRegeneration, float spellDamageAmplification)
        {
            Health = health;
            HealthRegeneration = healthRegeneration;
            MagicResistance = magicResistance;

            Armor = armor;
            AttackSpeed = attackSpeed;
            MoveSpeedAmplification = moveSpeedAmplification;

            Mana = mana;
            ManaRegeneration = manaRegeneration;
            SpellDamageAmplification = spellDamageAmplification;
        }

        public static Statistics FromAttributes(Attributes attributes) =>
            new Statistics(
                attributes.StrengthToHealth(), attributes.StrengthToHealthRegeneration(), attributes.StrengthToMagicResistance(),
                attributes.AgilityToArmor(), attributes.AgilityToAttackSpeed(), attributes.AgilityToMovementSpeed(),
                attributes.IntelligenceToMaximumMana(), attributes.IntelligenceToManaRegeneration(), attributes.IntelligenceToSpellDamage());

        public float Health { get; set; }
        public float TerrariaHealth => Health * TERRARIA_HEALTH_RATIO;

        public float HealthRegeneration { get; set; }
        public float TerrariaHealthRegeneration => HealthRegeneration * TERRARIA_HEALTH_RATIO;

        public float MagicResistance { get; set; }


        public float Armor { get; set; }
        public float AttackSpeed { get; set; }
        public float MoveSpeedAmplification { get; set; }


        public float Mana { get; set; }
        public float TerrariaMana => Mana * TERRARIA_MANA_RATIO;

        public float ManaRegeneration { get; set; }
        public float TerrariaManaRegeneration => ManaRegeneration * TERRARIA_MANA_RATIO;

        public float SpellDamageAmplification { get; set; }

        public float Damage { get; set; }
    }
}
