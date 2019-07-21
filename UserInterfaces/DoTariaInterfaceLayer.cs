using System;
using Terraria.UI;

namespace DoTaria.UserInterfaces
{
    public class DoTariaInterfaceLayer : GameInterfaceLayer
    {
        public DoTariaInterfaceLayer(string name, InterfaceScaleType scaleType, DoTariaUIState uiState) : base(name, scaleType)
        {
            UIState = uiState;
        }

        protected override bool DrawSelf()
        {
            throw new NotImplementedException();
        }

        public UIState UIState { get; }
    }
}
