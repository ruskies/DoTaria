using System;
using DoTaria.Abilities;
using DoTaria.Commons;
using DoTaria.Enums;
using DoTaria.Extensions;
using DoTaria.Helpers;
using DoTaria.Heroes.Invoker.Abilities.Elements;
using DoTaria.Players;
using Terraria.ID;

namespace DoTaria.Heroes.Invoker.Abilities.InvokableAbilities
{
    public class GhostWalkAbility : InvokableAbility
    {
        public GhostWalkAbility() : base("ghostWalk", "Ghost Walk", 
            AbilityType.Active, AbilityTargetType.NoTarget, AbilityTargetFaction.Self, AbilityTargetUnitType.None, DamageType.None)
        {
        }

        public override string GetAbilityTooltip(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            "Generates a wall of solid ice directly in front of Invoker for a duration based on the level of Quas. The bitter cold emanating from it greatly slows nearby enemies based on the level of Quas and deals damage each second based on the level of Exort.\n\n" +
            $"Duration: {AbilitiesHelper.GenerateCleanSlashedString(GetDuration, dotariaPlayer, AbilityDefinitionManager.Instance.Quas)}\n" +
            $"Radius: {AbilitiesHelper.GenerateCleanSlashedString(InternalGetCastRange, dotariaPlayer, AbilityDefinitionManager.Instance.Quas)}\n" +
            $"Enemy slow (Quas) (%):\n{AbilitiesHelper.GenerateCleanSlashedString((player, ability) => GetEnemyMoveSpeedChange(player, ability) * 100, dotariaPlayer, AbilityDefinitionManager.Instance.Quas)}\n" +
            $"Self slow (Wex) (%):\n{AbilitiesHelper.GenerateCleanSlashedString((player, ability) => GetSelfMoveSpeedChange(player, ability) * 100, dotariaPlayer, AbilityDefinitionManager.Instance.Wex)}";


        public override bool CastAbility(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, bool casterIsLocalPlayer)
        {
            dotariaPlayer.player.AddBuff(BuffID.Invisibility, DoTariaMath.TICKS_PER_SECOND * 60);
            
            return base.CastAbility(dotariaPlayer, playerAbility, casterIsLocalPlayer);
        }


        public static float GetEnemyMoveSpeedChange(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            -0.15f - 0.05f * playerAbility.Level - (dotariaPlayer.HasAghanims() ? 0.05f : 0);

        public static float GetSelfMoveSpeedChange(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            -0.4f + 0.1f * playerAbility.Level + (dotariaPlayer.HasAghanims() ? 0.1f : 0);

        public static float GetDuration(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 100;

        public override float GetCastRange(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 400;


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 45;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 200;


        public override Func<AbilityDefinitionManager, InvokerElementAbility[]> RequiredElements { get; } = manager => 
            new InvokerElementAbility[] { manager.Quas, manager.Quas, manager.Wex };
    }
}