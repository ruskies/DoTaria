using Microsoft.Xna.Framework;
using Terraria;

namespace DoTaria.Commons
{
    public static class DoTariaMath
    {
        public const int TICKS_PER_SECOND = 60;
        public const float 
            TERRARIA_RANGE_RATIO = 1 / 2f,
            TERRARIA_SPEED_RATIO = 15 / 1300f;


        public static Vector2 CalculateSpeedForMouse(Player player, float speed) => CalculateSpeedForTarget(player, Main.MouseWorld, speed);
        public static Vector2 CalculateSpeedForTarget(Player player, Vector2 destination, float speed) => CalculateSpeedForTarget(player.Center, destination, speed);

        public static Vector2 CalculateSpeedForTarget(Vector2 position, Vector2 destination, float speed) => Vector2.Normalize(destination - position) * speed;
    }
}
