using DoTaria.Heroes.ShadowFiend.Abilities;
using DoTaria.Players;
using DoTaria.Extensions;
using System;
using Terraria;
using Terraria.DataStructures;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace DoTaria.Heroes.ShadowFiend
{
    public sealed class ShadowFiendHero : HeroDefinition
    {
        public const string UNLOCALIZED_NAME = "heroes.shadowFiend";

        public ShadowFiendHero() : base(UNLOCALIZED_NAME)
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
