namespace DoTaria.UserInterfaces.Abilities
{
    public class AbilitiesUIState : DoTariaUIState
    {
        private DoTariaUIPanel _panel;

        public override void OnInitialize()
        {
            base.OnInitialize();

            _panel = new DoTariaUIPanel();
            _panel.SetPadding(0);

            _panel.Left.Set(400f, 0);
            _panel.Top.Set(0f, 0.8f);

            _panel.Width.Set(170f, 0f);
            _panel.Height.Set(70f, 0f);
        }
    }
}