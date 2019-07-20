using DoTaria.Buffs;
using DoTaria.Players;
using Terraria;

namespace DoTaria.Heroes.ShadowFiend.Abilities
{
    public sealed class NecromasteryBuff : DoTariaBuff
    {
        public NecromasteryBuff() : base("Necromastery", 
            "Gives you bonus damage based on how many souls you've collected." +
            "\n'Harvested souls swirl in and out of the Abysm, empowering the Shadow Fiend to increase the size of his collection.'",
            hideTime: true, persistent: true, canBeCleared: false)
        {
        }


        public override void ModifyBuffTip(ref string tip, ref int rare)
        {
            base.ModifyBuffTip(ref tip, ref rare);

            DoTariaPlayer dotariaPlayer = Main.LocalPlayer.GetModPlayer<DoTariaPlayer>();

            tip += $"\n\nYou currently have {dotariaPlayer.Souls} souls, giving you an extra {dotariaPlayer.Souls * 2} damage to all physical attacks.";
        }
    }
}