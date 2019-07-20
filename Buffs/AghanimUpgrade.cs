using Terraria;

namespace DoTaria.Buffs
{
    public sealed class AghanimUpgrade : DoTariaBuff
    {
        public AghanimUpgrade() : base("Aghanim's Strength", "Your abilities are enhanced by the power of Aghanim!", hideTime: true, persistent: true, canBeCleared: false)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            Main.buffNoTimeDisplay[Type] = true;
        }
    }
}
