using System;
using System.Collections.Generic;
using DoTaria.Attribute;
using DoTaria.Extensions;
using Terraria.ModLoader;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private void PreUpdateAttributes()
        {
            float strength = Hero.BaseAttributes.Strength + Hero.GainPerLevel.Strength * (Level - 1);

            List<IGiveStrength> extraStrength = player.GetItemsByType<IGiveStrength>(armor: true, accessories: true);

            for (int i = 0; i < extraStrength.Count; i++)
                strength += extraStrength[i].GetGivenStrength(this);


            float agility = Hero.BaseAttributes.Strength + Hero.GainPerLevel.Strength * (Level - 1);

            List<IGiveAgility> extraAgility = player.GetItemsByType<IGiveAgility>(armor: true, accessories: true);

            for (int i = 0; i < extraAgility.Count; i++)
                agility += extraAgility[i].GetGivenAgility(this);


            float intelligence = Hero.BaseAttributes.Strength + Hero.GainPerLevel.Strength * (Level - 1);

            List<IGiveIntelligence> extraIntelligence = player.GetItemsByType<IGiveIntelligence>(armor: true, accessories: true);

            for (int i = 0; i < extraIntelligence.Count; i++)
                intelligence += extraIntelligence[i].GetGivenIntelligence(this);


            Attributes = new Attributes(strength, agility, intelligence);
        }

        private void PreUpdateMovementAttributes()
        {
            player.statLifeMax2 += (int) Math.Ceiling(Attributes.HealthFromStrength(Strength));
            player.lifeRegen += (int) Attributes.HealthRegenerationFromStrength(Strength);

            player.statDefense += (int) Math.Ceiling(Attributes.ArmorFromStrength(Strength) + Attributes.ArmorFromAgility(Agility));
            player.maxRunSpeed += (int) Math.Ceiling(Attributes.MovementSpeedPerAgility(Agility));

            player.statManaMax2 += (int) Math.Ceiling(Attributes.MaximumManaFromIntelligence(Intelligence));
            player.manaRegenBonus += (int) Math.Ceiling(Attributes.ManaRegenerationFromIntelligence(Intelligence));
            player.magicDamageMult += (int) Attributes.SpellDamageFromIntelligence(Intelligence);
        }


        public Attributes Attributes { get; private set; }

        public float Strength
        {
            get
            {
                
            }
        }

        public float Agility
        {
            get { return Hero.BaseAttributes.Agility + Hero.GainPerLevel.Agility * (Level - 1); }
        }

        public float Intelligence
        {
            get { return Hero.BaseAttributes.Intelligence + Hero.GainPerLevel.Intelligence * (Level - 1); }
        }
    }
}
