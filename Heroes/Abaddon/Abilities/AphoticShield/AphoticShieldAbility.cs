using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.Abaddon.Abilities.AphoticShield
{
    public sealed class AphoticShieldAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = AbaddonHero.UNLOCALIZED_NAME + ".aphoticShield";


        public AphoticShieldAbility() : base(UNLOCALIZED_NAME, "Aphotic Shield", 
            AbilityType.Active, AbilityTargetType.TargetUnit, AbilityTargetFaction.Self & AbilityTargetFaction.Allies, DoTaria.Abilities.AbilityTargetUnitType.Living, 
            DamageType.None, AbilitySlot.Second, 1, 4, baseCastRange: 500)
        {
        }


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 14 - playerAbility.Level * 2;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 95 + playerAbility.Level * 5;
    }
}