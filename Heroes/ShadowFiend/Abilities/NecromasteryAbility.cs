using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.ShadowFiend.Abilities
{
    public sealed class NecromasteryAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME_SUFFIX = "necromastery";

        public NecromasteryAbility() : base(ShadowFiendHero.UNLOCALIZED_NAME + '.' + UNLOCALIZED_NAME_SUFFIX, "Necromastery", AbilityType.Passive, DamageType.Physical, AbilitySlot.Fourth, 4)
        {
        }


        public int GetMaxSouls(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 4 + playerAbility.Level * 8;


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;
    }
}