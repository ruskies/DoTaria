using Terraria.ModLoader;

namespace DoTarria.Buffs
{
    public abstract class DoTarriaBuff : ModBuff
    {
        private readonly string _displayName, _tooltip;

        protected DoTarriaBuff(string displayName, string tooltip)
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