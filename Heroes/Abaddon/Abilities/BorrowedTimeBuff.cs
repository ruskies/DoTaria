using DoTaria.Buffs;

namespace DoTaria.Heroes.Abaddon.Abilities
{
    public sealed class BorrowedTimeBuff : DoTariaBuff
    {
        public BorrowedTimeBuff() : base("Borrowed Time!", "What hurts you heals you!", canBeCleared: false, save: true)
        {
        }
    }
}