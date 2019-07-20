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
    public sealed class HeroShadowFiend : HeroDefinition
    {
        public const string UNLOCALIZED_NAME = "heroes.shadowFiend";

        public HeroShadowFiend() : base(UNLOCALIZED_NAME)
        {
        }


        public override void ApplyInitialBuffs(DoTariaPlayer dotarriaPlayer)
        {
            dotarriaPlayer.player.AddBuff<BuffNecromastery>(int.MaxValue);
        }


        public override void OnPlayerDeath(DoTariaPlayer dotarriaPlayer, double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            dotarriaPlayer.Souls = (int)Math.Ceiling(dotarriaPlayer.Souls / 2f);
        }

        public override void OnPlayerKilledNPC(DoTariaPlayer dotarriaPlayer, NPC npc)
        {
            dotarriaPlayer.Souls += 1;

            if (npc.boss)
                dotarriaPlayer.Souls += 15;
        }


        public override void ModifyWeaponDamage(DoTariaPlayer dotarriaPlayer, Item item, ref float add, ref float mult, ref float flat)
        {
            if (item.melee || item.ranged)
                flat += dotarriaPlayer.Souls * 2;
        }
    }
}
