using System;

namespace DoTaria.Attributes
{
    public class Attributes
    {
        private const float
            HEALTH_PER_STRENGTH = 20,
            HEALTH_REGENERATION_PER_STRENGTH = 0.1f,
            ARMOR_PER_STRENGTH = 0.16f / 2,

            ARMOR_PER_AGILITY = 0.16f / 2,
            ATTACK_SPEED_PER_AGILITY = 1,
            MOVEMENT_SPEED_PER_AGILITY = 0.0005f,

            MAXIMUM_MANA_PER_INTELLIGENCE = 12,
            MANA_REGENERATION = 0.05f,
            SPELL_DAMAGE = 0.0007f;

        public Attributes(float strength, float agility, float intelligence)
        {
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
        }

        public float Strength { get; }
        public float Agility { get; }
        public float Intelligence { get; }

        public static float HealthFromStrength(float strength) => strength * HEALTH_PER_STRENGTH;
        public static float HealthRegenerationFromStrength(float strength) => strength * HEALTH_REGENERATION_PER_STRENGTH;
        public static float ArmorFromStrength(float strength) => strength * ARMOR_PER_STRENGTH;


    }
}