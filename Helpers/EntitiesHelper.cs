using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;

namespace DoTaria.Helpers
{
    public static class EntitiesHelper
    {
        public static Player GetLocalHoveredPlayer()
        {
            Vector2 mousePosition = Main.MouseWorld;

            for (int i = 0; i < Main.player.Length; i++)
                if (Main.player[i].getRect().Contains((int)mousePosition.X, (int)mousePosition.Y))
                    return Main.player[i];

            return null;
        }

        public static NPC GetLocalHoveredNPC()
        {
            Vector2 mousePosition = Main.MouseWorld;

            for (int i = 0; i < Main.npc.Length; i++)
                if (Main.npc[i].active && Main.npc[i].getRect().Contains((int)mousePosition.X, (int)mousePosition.Y))
                    return Main.npc[i];

            return null;
        }

        public static void GetLocalHoveredEntity(out Player player, out NPC npc)
        {
            player = GetLocalHoveredPlayer();
            npc = GetLocalHoveredNPC();
        }

        public static List<Player> GetPlayersInRange(Vector2 origin, int maxDistance)
        {
            List<Player> players = new List<Player>();

            for (int i = 0; i < Main.player.Length; i++)
                if (Vector2.Distance(Main.player[i].Center, origin) <= maxDistance)
                    players.Add(Main.player[i]);

            return players;
        }
    }
}