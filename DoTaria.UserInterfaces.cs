using System.Collections.Generic;
using DoTaria.UserInterfaces;
using Terraria.ModLoader;
using Terraria.UI;

namespace DoTaria
{
    public sealed partial class DoTaria : Mod
    {
        private void LoadInterfaces()
        {

        }

        private void UnloadInterfaces()
        {

        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int abilitiesBarLayerIndex = layers.FindIndex(l => l.Name.Contains("Resource Bars"));

            if (abilitiesBarLayerIndex != -1)
                layers.Add(abilitiesBarLayerIndex, new DoTariaInterfaceLayer(typeof()));
        }
    }
}
