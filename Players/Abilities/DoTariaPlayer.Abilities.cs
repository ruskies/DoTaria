using System.Collections.Generic;
using DoTaria.Abilities;
using Terraria.ModLoader;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private Dictionary<AbilityDefinition, PlayerAbility> _acquiredAbilities;

        private void InitializeAbilities()
        {
            _acquiredAbilities = new Dictionary<AbilityDefinition, PlayerAbility>();
        }
    }
}
