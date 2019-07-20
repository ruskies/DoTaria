using DoTarria.Buffs;
using DoTarria.Players;
using Terraria;

namespace DoTarria.Heroes.ShadowFiend.Abilities
{
    public sealed class BuffNecromastery : DoTarriaBuff
    {
        public BuffNecromastery() : base("Necromastery", "Gives you bonus damage based on how many souls you've collected.")
        {
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            canBeCleared = false;

            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.persistentBuff[Type] = true;
        }

        public override void ModifyBuffTip(ref string tip, ref int rare)
        {
            base.ModifyBuffTip(ref tip, ref rare);

            DoTarriaPlayer dotarriaPlayer = Main.LocalPlayer.GetModPlayer<DoTarriaPlayer>();

            tip += $"\nYou currently have {dotarriaPlayer.Souls} souls, giving you an extra {dotarriaPlayer.Souls * 2} melee and ranged damage.";
        }
    }
}