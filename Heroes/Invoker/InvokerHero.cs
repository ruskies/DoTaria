using DoTaria.Abilities;
using DoTaria.Attribute;
using DoTaria.Extensions;
using DoTaria.Heroes.Invoker.Abilities.Elements;
using DoTaria.Players;
using DoTaria.Statistic;
using Terraria;
using Terraria.DataStructures;

namespace DoTaria.Heroes.Invoker
{
    public sealed class InvokerHero : HeroDefinition
    {
        public const string UNLOCALIZED_NAME = UNLOCALIZED_NAME_PREFIX + "invoker";

        public InvokerHero() : base(UNLOCALIZED_NAME, "Invoker", new Attributes(18, 14, 14), new Attributes(2.4f, 1.9f, 4.6f),
            new Statistics(200, 0, 0.25f, 0, 0.59f, 0f, 75, 0, 0), 
            280,
            AbilityDefinitionManager.Instance.Quas, AbilityDefinitionManager.Instance.Wex, AbilityDefinitionManager.Instance.Exort, AbilityDefinitionManager.Instance.Invoke, AbilityDefinitionManager.Instance.GhostWalk)
        {
        }

        public override string GetAghanimsUpgrade(DoTariaPlayer dotariaPlayer) =>
            "Decreases cooldown from Invoke. Adds one level to the stats provided\nby Quas, Wex and Exort on all invoked spells.\n\nScepter cooldown: 2";


        public override void VerifyAndApplyBuffs(DoTariaPlayer dotariaPlayer)
        {
            if (dotariaPlayer.HasAbility(AbilityDefinitionManager.Instance.Quas) && !dotariaPlayer.player.HasBuff<QuasBuff>())
                dotariaPlayer.player.AddBuff<QuasBuff>(int.MaxValue);

            if (dotariaPlayer.HasAbility(AbilityDefinitionManager.Instance.Wex) && !dotariaPlayer.player.HasBuff<WexBuff>())
                dotariaPlayer.player.AddBuff<WexBuff>(int.MaxValue);

            if (dotariaPlayer.HasAbility(AbilityDefinitionManager.Instance.Exort) && !dotariaPlayer.player.HasBuff<ExortBuff>())
                dotariaPlayer.player.AddBuff<ExortBuff>(int.MaxValue);
        }


        public override void OnPlayerDeath(DoTariaPlayer dotariaPlayer, double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) =>
            dotariaPlayer.currentInvokerElements.Clear();

        public override void OnPlayerPreUpdateMovement(DoTariaPlayer dotariaPlayer) =>
            dotariaPlayer.ForAllCastElements((p, e) => e.CastElementPreUpdateMovement(p, p.AcquiredAbilities[e]));

        public override void OnPlayerResetEffects(DoTariaPlayer dotariaPlayer) =>
            dotariaPlayer.ForAllCastElements((p, e) => e.CastElementPlayerResetEffects(p, p.AcquiredAbilities[e]));


        public override void ModifyWeaponDamage(DoTariaPlayer dotariaPlayer, Item item, ref float add, ref float mult, ref float flat)
        {
            base.ModifyWeaponDamage(dotariaPlayer, item, ref add, ref mult, ref flat);

            foreach (InvokerElementAbility ability in dotariaPlayer.CurrentElements)
                ability.CastElementModifyWeaponDamage(dotariaPlayer, dotariaPlayer.AcquiredAbilities[ability], item, ref add, ref mult, ref flat);
        }
    }
}
