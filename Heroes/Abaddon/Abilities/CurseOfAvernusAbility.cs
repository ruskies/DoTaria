﻿using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.Abaddon.Abilities
{
    public sealed class CurseOfAvernusAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = AbaddonHero.UNLOCALIZED_NAME + ".curseOfAvernus";

        public CurseOfAvernusAbility() : base(UNLOCALIZED_NAME, "Curse of Avernus", AbilityType.Passive, DamageType.None, AbilitySlot.Third, 4)
        {
        }


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;
    }
}