using DoTarria.Heroes.ShadowFiend.Abilities;
using DoTarria.Players;
using DoTarria.Extensions;
using System;
using Terraria;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace DoTarria.Heroes.ShadowFiend
{
    public sealed class HeroShadowFiend : HeroDefinition
    {
        public const string UNLOCALIZED_NAME = "heroes.shadowFiend";

        public HeroShadowFiend() : base(UNLOCALIZED_NAME)
        {
        }


        public override void ApplyInitialBuffs(DoTarriaPlayer dotarriaPlayer)
        {
            dotarriaPlayer.player.AddBuff<BuffNecromastery>(int.MaxValue);
        }


        public override void OnPlayerDeath(DoTarriaPlayer dotarriaPlayer, double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            dotarriaPlayer.Souls = (int)Math.Ceiling(dotarriaPlayer.Souls / 2f);
        }

        public override void OnPlayerKilledNPC(DoTarriaPlayer dotarriaPlayer, NPC npc)
        {
            dotarriaPlayer.Souls += 1;

            if (npc.boss)
                dotarriaPlayer.Souls += 15;
        }


        public override void ModifyWeaponDamage(DoTarriaPlayer dotarriaPlayer, Item item, ref float add, ref float mult, ref float flat)
        {
            

            flat += dotarriaPlayer.Souls * 2;
        }
    }
}
