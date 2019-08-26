using DoTaria.Buffs;
using Terraria;

namespace DoTaria.Heroes.Abaddon.Abilities.CurseOfAvernus
{
    public sealed class FrostmourneAlliedBuff : DoTariaBuff
    {
        public FrostmourneAlliedBuff() : base("Frostmourne", "You have increased attack speed")
        {
        }


        public override void Update(Player player, ref int buffIndex)
        {
            // TODO Change this to detect the person who placed the curse on the enemy.
            player.meleeSpeed += 0.3f;
        }
    }
}