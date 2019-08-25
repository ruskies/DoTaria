using System;
using DoTaria.Extensions;
using DoTaria.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DoTaria.Helpers
{
    public static class AurasHelper
    {
        public static void ExecuteAuraNPC<T>(int auraRange, DoTariaPlayer dotariaPlayer, int linger) where T : ModBuff
        {
            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC npc = Main.npc[i];

                if (!npc.active)
                    continue;

                if (Vector2.Distance(npc.Center, dotariaPlayer.player.Center) <= auraRange)
                    npc.AddBuff<T>(linger);
            }
        }


        public static void ExecuteAuraPlayer<T>(int auraRange, DoTariaPlayer dotariaPlayer, int linger) where T : ModBuff
        {
            for (int i = 0; i < Main.player.Length; i++)
            {
                Player player = Main.player[i];

                if (Vector2.Distance(player.Center, dotariaPlayer.player.Center) <= auraRange)
                    player.AddBuff<T>(linger);
            }
        }
    }
}