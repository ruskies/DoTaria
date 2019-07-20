using DoTaria.Buffs;
using DoTaria.Players;
using Terraria;

namespace DoTaria.Heroes.ShadowFiend.Abilities
{
    public sealed class BuffNecromastery : DoTariaBuff
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

            DoTariaPlayer dotarriaPlayer = Main.LocalPlayer.GetModPlayer<DoTariaPlayer>();

            tip += $"\nYou currently have {dotarriaPlayer.Souls} souls, giving you an extra {dotarriaPlayer.Souls * 2} melee and ranged damage.";
        }
    }
}