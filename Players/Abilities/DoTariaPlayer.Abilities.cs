using System.Collections.Generic;
using DoTaria.Abilities;
using Terraria;
using Terraria.ModLoader;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        public bool HasAbility(AbilityDefinition ability) => AcquiredAbilities.ContainsKey(ability);

        public bool HasAbility(AbilityDefinition ability, int level) => HasAbility(ability) && level <= AcquiredAbilities[ability].Level;


        public PlayerAbility GetPlayerAbility(AbilityDefinition ability)
        {
            if (!HasAbility(ability))
                return null;

            return AcquiredAbilities[ability];
        }

        private void InitializeAbilities()
        {
            AcquiredAbilities = new Dictionary<AbilityDefinition, PlayerAbility>();
        }


        private void OnEnterWorldAbilities(Player player)
        {
            if (Main.LocalPlayer.whoAmI == player.whoAmI)
                DoTaria.Instance.AbilitiesUI.OnPlayerEnterWorld(this);
        }


        private void ResetEffectsAbilities()
        {
            LevelsSpent = 0;

            foreach (PlayerAbility playerAbility in AcquiredAbilities.Values)
                LevelsSpent = playerAbility.Level;
        }


        internal Dictionary<AbilityDefinition, PlayerAbility> AcquiredAbilities { get; private set; }

        public int LevelsSpent { get; private set; }
        public bool HasSpareLevels => LevelsSpent < Level;
    }
}
