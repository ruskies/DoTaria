using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;

namespace DoTaria.UserInterfaces.HeroStatistics
{
    public sealed class HeroStatisticsUIState : DoTariaUIState
    {
        private const string USERINTERFACES_HEROSTATISTICS_PREFIX = "UserInterfaces/HeroStatistics/";

        private DoTariaUIPanel _mainPanel;


        public HeroStatisticsUIState(Mod mod)
        {
            Mod = mod;
        }


        public override void OnInitialize()
        {
            base.OnInitialize();

            _mainPanel = new DoTariaUIPanel();

            
        }


        public Mod Mod { get; }
    }
}
