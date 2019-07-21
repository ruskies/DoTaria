using DoTaria.Heroes.ShadowFiend.Abilities;
using DoTaria.Players;
using DoTaria.Extensions;
using System;
using DoTaria.Abilities;
using Terraria;
using Terraria.DataStructures;
using DoTaria.Attribute;

namespace DoTaria.Heroes.ShadowFiend
{
    public sealed class ShadowFiendHero : HeroDefinition
    {
        public const string UNLOCALIZED_NAME = HeroDefinition.UNLOCALIZED_NAME_PREFIX + "shadowFiend";

        public ShadowFiendHero() : base(UNLOCALIZED_NAME, new Attributes(19, 20, 18), new Attributes(2.5f, 3.5f, 2.2f), 
            AbilityDefinitionManager.Instance.Necromastery)
        {
        }


        public override void VerifyAndApplyBuffs(DoTariaPlayer dotariaPlayer)
        {
            if (!dotariaPlayer.player.HasBuff<NecromasteryBuff>())
                dotariaPlayer.player.AddBuff<NecromasteryBuff>(int.MaxValue);
        }


        public override void OnPlayerDeath(DoTariaPlayer dotariaPlayer, double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            dotariaPlayer.Souls = (int)Math.Ceiling(dotariaPlayer.Souls / 2f);
        }

        public override void OnPlayerKilledNPC(DoTariaPlayer dotariaPlayer, NPC npc)
        {
            dotariaPlayer.Souls += 1;

            if (npc.boss)
                dotariaPlayer.Souls += 15;
        }


        public override void ModifyWeaponDamage(DoTariaPlayer dotariaPlayer, Item item, ref float add, ref float mult, ref float flat)
        {
            if (item.melee || item.ranged)
                flat += dotariaPlayer.Souls * 2;
        }        
    }
}
