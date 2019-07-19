﻿using DoTarria.Commons;
using DoTarria.Enums;

namespace DoTarria.Abilities
{
    public abstract class AbilityDefinition : IHasUnlocalizedName
    {
        protected AbilityDefinition(string unlocalizedName, string displayName, AbilityType abilityType, DamageType damageType)
        {
            UnlocalizedName = unlocalizedName;
            DisplayName = displayName;

            AbilityType = abilityType;
            DamageType = damageType;
        }





        public string UnlocalizedName { get; }
        public string DisplayName { get; }

        public AbilityType AbilityType { get; }
        public DamageType DamageType { get; }
    }
}