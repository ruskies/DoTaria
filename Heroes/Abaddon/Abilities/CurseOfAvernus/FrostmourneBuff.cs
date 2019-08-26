using DoTaria.Buffs;
using Terraria;

namespace DoTaria.Heroes.Abaddon.Abilities.CurseOfAvernus
{
    public sealed class FrostmourneBuff : DoTariaBuff
    {
        public FrostmourneBuff() : base("Frostmourne", "Hit by the Lord of the House of Avernus", canBeCleared: false)
        {
        }


        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.stepSpeed -= 0.175f;
        }
    }
}