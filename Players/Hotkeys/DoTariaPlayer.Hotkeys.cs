using System.Collections.Generic;
using DoTaria.Abilities;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private void ProcessTriggersHotkeys(TriggersSet triggersSet)
        {
            foreach (KeyValuePair<ModHotKey, AbilitySlot> kvp in DoTariaMod.Instance.ModHotKeys)
                if (kvp.Key.JustReleased)
                    TryActivateAbility(kvp.Value);
        }
    }
}
