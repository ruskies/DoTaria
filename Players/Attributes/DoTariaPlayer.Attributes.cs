using System;
using System.Collections.Generic;
using DoTaria.Attribute;
using DoTaria.Extensions;
using Terraria.ModLoader;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private const float 
            MAX_VANILLA_HEALTH = 500,
            MAX_VANILLA_MANA = 200;

        private void PreUpdateAttributes()
        {
            
        }

        private void PreUpdateMovementAttributes()
        {
            
        }


        private void ResetEffectsAttributes()
        {
            float strength = Hero.BaseAttributes.Strength + Hero.GainPerLevel.Strength * Level;

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


        public Attributes Attributes { get; private set; }
    }
}
