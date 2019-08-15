using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.Terrorblade.Abilities.Sunder
{
    public sealed class SunderAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = TerrorbladeHero.UNLOCALIZED_NAME + ".sunder";


        public SunderAbility() : base(UNLOCALIZED_NAME, "Sunder", AbilityType.Active, DamageType.None, AbilitySlot.Ultimate, 6, 3, baseCastRange: 475)
        {
        }


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 160 - playerAbility.Level * 40;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => (-100f * playerAbility.Level + 500) / (playerAbility.Level + 1);

    }
}