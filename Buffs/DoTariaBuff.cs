using Terraria.ModLoader;

namespace DoTaria.Buffs
{
    public abstract class DoTariaBuff : ModBuff
    {
        private readonly string _displayName, _tooltip;

        protected DoTariaBuff(string displayName, string tooltip)
        {
            _displayName = displayName;
            _tooltip = tooltip;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            DisplayName.SetDefault(_displayName);
            Description.SetDefault(_tooltip);
        }
    }
}