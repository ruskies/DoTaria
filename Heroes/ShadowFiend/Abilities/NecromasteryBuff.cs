using DoTarria.Buffs;
using DoTarria.Players;
using Terraria;

namespace DoTarria.Heroes.ShadowFiend.Abilities
{
    public sealed class NecromasteryBuff : DoTarriaBuff
    {
        public NecromasteryBuff() : base("Necromastery", "Gives you bonus damage based on how many souls you've collected.")
        {
        }

        public override void ModifyBuffTip(ref string tip, ref int rare)
        {
            base.ModifyBuffTip(ref tip, ref rare);

            DoTarriaPlayer dotarriaPlayer = Main.LocalPlayer.GetModPlayer<DoTarriaPlayer>();

            tip += $"\nYou currently have {dotarriaPlayer.Souls} souls, giving you an extra {dotarriaPlayer.Souls * 2} melee and ranged damage.";
        }

        public override void Update(Player player, ref int buffIndex)
        {
            base.Update(player, ref buffIndex);

            DoTarriaPlayer dotarriaPlayer = DoTarriaPlayer.Get(Main.LocalPlayer);

            int extraDamage = dotarriaPlayer.Souls * 2;

            player.meleeDamage += extraDamage;
            player.rangedDamage += extraDamage;
        }
    }
}