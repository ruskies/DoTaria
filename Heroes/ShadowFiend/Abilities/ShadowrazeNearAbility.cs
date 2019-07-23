using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.ShadowFiend.Abilities
{
    public sealed class ShadowrazeNearAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = "shadowrazeNear";

        public ShadowrazeNearAbility() : base(ShadowFiendHero.UNLOCALIZED_NAME + '.' + UNLOCALIZED_NAME, "Shadowraze (Near)", AbilityType.Active, DamageType.Magical, AbilitySlot.First, 4)
        {
        }


        // TODO Adjust with talent.
        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => ShadowrazeDefaultMath.GetCooldown(dotariaPlayer, playerAbility);

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => ShadowrazeDefaultMath.GetManaCost(dotariaPlayer, playerAbility);
    }
}
