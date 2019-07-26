using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.ShadowFiend.Abilities
{
    public sealed class RequiemofSoulsAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = "requiemofSouls";

        public RequiemofSoulsAbility() : base(ShadowFiendHero.UNLOCALIZED_NAME + '.' + UNLOCALIZED_NAME, "Requiem of Souls", AbilityType.Active, DamageType.Magical, AbilitySlot.Ultimate, 6, 3)
        {
        }


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 130 - playerAbility.Level * 10;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 125 + playerAbility.Level * 25;
    }
}
