using DoTaria.Heroes.ShadowFiend.Abilities;
using DoTaria.Players;
using DoTaria.Extensions;
using System;
using DoTaria.Abilities;
using Terraria;
using Terraria.DataStructures;
using DoTaria.Attribute;
using DoTaria.Heroes.ShadowFiend.Abilities.Necromastery;
using DoTaria.Statistic;

namespace DoTaria.Heroes.ShadowFiend
{
    public sealed class ShadowFiendHero : HeroDefinition
    {
        public const string UNLOCALIZED_NAME = UNLOCALIZED_NAME_PREFIX + "shadowFiend";

        public ShadowFiendHero() : base(UNLOCALIZED_NAME, "Shadow Fiend", new Attributes(19, 20, 18), new Attributes(2.5f, 3.5f, 2.2f), 
            new Statistics(200, 0.25f, 0.25f, 0, 0.59f, 0, 75, 0.3f, 0),
            305,
            AbilityDefinitionManager.Instance.Necromastery, AbilityDefinitionManager.Instance.PresenceoftheDarkLord, AbilityDefinitionManager.Instance.RequiemofSouls,
            AbilityDefinitionManager.Instance.ShadowrazeFar, AbilityDefinitionManager.Instance.ShadowrazeMiddle, AbilityDefinitionManager.Instance.ShadowrazeNear)
        {
        }


        public override void VerifyAndApplyBuffs(DoTariaPlayer dotariaPlayer)
        {
            if (dotariaPlayer.HasAbility(AbilityDefinitionManager.Instance.Necromastery) && !dotariaPlayer.player.HasBuff<NecromasteryBuff>())
                dotariaPlayer.player.AddBuff<NecromasteryBuff>(int.MaxValue);
        }


        public override void OnNPCHitByProjectile(DoTariaPlayer dotariaPlayer, NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            
        }

        public override void OnPlayerDeath(DoTariaPlayer dotariaPlayer, double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            dotariaPlayer.Souls = (int)Math.Ceiling(dotariaPlayer.Souls / 2f);
        }
    }
}
