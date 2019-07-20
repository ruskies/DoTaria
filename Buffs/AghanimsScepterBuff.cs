using Terraria;

namespace DoTaria.Buffs
{
    public sealed class AghanimsScepterBuff : DoTariaBuff
    {
        public AghanimsScepterBuff() : base("Aghanim's Scepter Upgrade", "Your abilities are enhanced by the power of Aghanim!", hideTime: true, persistent: true, canBeCleared: false)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            Main.buffNoTimeDisplay[Type] = true;
        }
    }
}
