using System;
using Terraria;
using Terraria.UI;

namespace DoTaria.UserInterfaces
{
    public class DoTariaInterfaceLayer : GameInterfaceLayer
    {
        public DoTariaInterfaceLayer(string name, InterfaceScaleType scaleType, DoTariaUIState uiState, UserInterface userInterface) : base(name, scaleType)
        {
            UIState = uiState;
            UserInterface = userInterface;
        }

        protected override bool DrawSelf()
        {
            if (UIState.Visible)
            {
                UserInterface.Update(Main._drawInterfaceGameTime);
                UIState.Draw(Main.spriteBatch);
            }

            return true;
        }

        public DoTariaUIState UIState { get; }
        public UserInterface UserInterface { get; }
    }
}
