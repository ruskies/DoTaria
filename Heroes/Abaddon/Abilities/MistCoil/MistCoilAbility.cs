
using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.Abaddon.Abilities.MistCoil
{
    public sealed class MistCoilAbility : AbilityDefinition
    {
        private const string UNLOCALIZED_NAME = AbaddonHero.UNLOCALIZED_NAME + ".mistCoil";

        public MistCoilAbility() : base(UNLOCALIZED_NAME, "Mist Coil", AbilityType.Active, DamageType.Pure, AbilitySlot.First, 1, 4)
        {
        }


        public override void OnAbilityCasted(DoTariaPlayer dotariaPlayer)
        {

        }


        // TODO Add support for talents.
        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 4.5f;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 50;
    }
}
