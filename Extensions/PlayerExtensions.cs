using Terraria;
using Terraria.ModLoader;

namespace DoTaria.Extensions
{
    public static class PlayerExtensions
    {
        public static bool HasBuff<T>(this Player player) where T : ModBuff => player.HasBuff(typeof(T).GetModFromType().BuffType<T>());

        public static void AddBuff<T>(this Player player, int time, bool quiet = true) where T : ModBuff
        {
            player.AddBuff(typeof(T).GetModFromType().BuffType<T>(), time, quiet);
        }
    }
}
