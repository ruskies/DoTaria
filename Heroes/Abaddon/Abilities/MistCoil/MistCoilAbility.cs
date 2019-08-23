
using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;
using Terraria;

namespace DoTaria.Heroes.Abaddon.Abilities.MistCoil
{
    public sealed class MistCoilAbility : AbilityDefinition
    {
        private const string UNLOCALIZED_NAME = AbaddonHero.UNLOCALIZED_NAME + ".mistCoil";

        public MistCoilAbility() : base(UNLOCALIZED_NAME, "Mist Coil", AbilityType.Active, AbilityTargetType.TargetUnit, AbilityTargetFaction.Allies & AbilityTargetFaction.Enemies, DamageType.Pure, AbilitySlot.First, 1, 4)
        {
        }


        public override bool CastAbility(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, bool casterIsLocalPlayer)
        {
            if (casterIsLocalPlayer)
            {
                Projectile mistCoil = Projectile.NewProjectile()
            }
        }


        // TODO Add support for talents.
        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 4.5f;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 50;
    }
}
