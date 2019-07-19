using Terraria;
using Terraria.ModLoader;

namespace DoTarria.Extensions
{
    public static class BuffCheckExtensions
    {
        public static bool HasBuff<T>(this Players player) where T : ModBuff => player.HasBuff(typeof(T).GetModFromType().BuffType<T>());
    }
}