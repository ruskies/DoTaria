using System.ComponentModel;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Config;

namespace DoTaria
{
    [Label("DoTaria Global Configuration")]
    public sealed class DoTariaGlobalConfiguration : ModConfig
    {
        [Label("Enable Mod Compatibility"), Tooltip("If true, DoTaria will add to the player stats, such as Max Life, Mana, etc. instead of setting them to values.\nCan lead to a very unbalanced experience."), DefaultValue(false)]
        public bool EnableModCompatibility { get; set; }


        [Label("Use Custom Mana Restore for Stars"), Tooltip("If true, Mana Stars will restore a % of your max mana."), DefaultValue(true)]
        public bool CustomManaRestore { get; set; }

        [Label("% Mana Restored on Mana Star"), Tooltip("How much of your maximum mama should be restored.\n0 = 0%, 0.5 = 50%, 1 = 100%"), DefaultValue(0.03f)]
        public float ManaRestoredOnStarPercentage { get; set; }

        public override ConfigScope Mode => ConfigScope.ServerSide;
    }

    [Label("DoTaria Client Configuration")]
    public sealed class DoTariaClientConfiguration : ModConfig
    {
        [Label("Ability Panel Background Color"), DefaultValue(typeof(Color), "40, 40, 40, 100")]
        public Color AbilityPanelBackgroundColor { get; set; }

        [Label("Ability Panel Border Color"), DefaultValue(typeof(Color), "0, 0, 0, 100")]
        public Color AbilityPanelBorderColor { get; set; }

        public override ConfigScope Mode => ConfigScope.ClientSide;
    }
}