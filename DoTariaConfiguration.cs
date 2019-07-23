using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace DoTaria
{
    public sealed class DoTariaConfiguration : ModConfig
    {
        [Label("Enable Mod Compatibility"), Tooltip("If true, DoTaria will add to the player stats, such as Max Life, Mana, etc. instead of setting them to values.\nCan lead to a very unbalanced experience."), DefaultValue(false)]
        public bool EnableModCompatibility { get; set; }

        public override ConfigScope Mode => ConfigScope.ServerSide;
    }
}