using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;
using DoTaria.Statistic;
using Terraria;

namespace DoTaria.Heroes.ShadowFiend.Abilities
{
    public sealed class RequiemofSoulsAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = "requiemofSouls";

        public RequiemofSoulsAbility() : base(ShadowFiendHero.UNLOCALIZED_NAME + '.' + UNLOCALIZED_NAME, "Requiem of Souls", 
            AbilityType.Active, AbilityTargetType.NoTarget, AbilityTargetFaction.Enemies, AbilityTargetUnitType.Living,
            DamageType.Magical, AbilitySlot.Ultimate, 6, 3)
        {
            if (Main.rand.Next(0, 1000) > 995)
                DisplayName = "Golden Experience Requiem";
        }


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 130 - playerAbility.Level * 10;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => (125 + playerAbility.Level * 25) * Statistics.TERRARIA_MANA_RATIO;
    }
}
