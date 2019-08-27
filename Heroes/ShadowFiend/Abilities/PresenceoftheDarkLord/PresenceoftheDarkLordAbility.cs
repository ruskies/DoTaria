using DoTaria.Abilities;
using DoTaria.Commons;
using DoTaria.Enums;
using DoTaria.Extensions;
using DoTaria.Helpers;
using DoTaria.Players;

namespace DoTaria.Heroes.ShadowFiend.Abilities.PresenceoftheDarkLord
{
    public sealed class PresenceoftheDarkLordAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = "presenceoftheDarkLord"; 

        public PresenceoftheDarkLordAbility() : base(ShadowFiendHero.UNLOCALIZED_NAME + '.' + UNLOCALIZED_NAME, "Presence of the Dark Lord", 
            AbilityType.Passive, AbilityTargetType.NoTarget, AbilityTargetFaction.Enemies, AbilityTargetUnitType.Living, DamageType.None, AbilitySlot.Fifth, 1, 4, baseCastRange: 700)
        {
        }

        public override string GetAbilityTooltip(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            "Shadow Fiend's presence reduces the armor of nearby enemies.\n\n" +
            $"Reduction (%): {AbilitiesHelper.GenerateCleanSlashedString((player, ability) => GetDefenseReduction(player, ability) * 100, dotariaPlayer, this)}\n" +
            $"Range: {AbilitiesHelper.GenerateCleanSlashedString(InternalGetCastRange, dotariaPlayer, this)}";


        public override void OnPlayerPreUpdate(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility)
        {
            AurasHelper.ExecuteAuraNPC<PresenceoftheDarkLordBuff>((int) InternalGetCastRange(dotariaPlayer, playerAbility), dotariaPlayer, (int)(0.5 * DoTariaMath.TICKS_PER_SECOND));
        }

        public float GetDefenseReduction(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0.15f + 0.05f * playerAbility.Level;


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;
    }
}
