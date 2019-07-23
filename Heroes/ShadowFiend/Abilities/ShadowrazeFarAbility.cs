using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.ShadowFiend.Abilities
{
    public sealed class ShadowrazeFarAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = "shadowrazeFar";

        public ShadowrazeFarAbility() : base(ShadowFiendHero.UNLOCALIZED_NAME + '.' + UNLOCALIZED_NAME, "Shadowraze (Far)", AbilityType.Active, DamageType.Magical, AbilitySlot.Third, 4)
        {
        }


        // TODO Add support for talents.
        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => ShadowrazeDefaultMath.GetCooldown(dotariaPlayer, playerAbility);

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => ShadowrazeDefaultMath.GetManaCost(dotariaPlayer, playerAbility);
    }
}
