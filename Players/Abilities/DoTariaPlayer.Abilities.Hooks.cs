using System.Collections.Generic;
using DoTaria.Abilities;
using Terraria;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer
    {
        private void InitializeAbilities()
        {
            DisplayedAbilities = new List<AbilityDefinition>();
            AcquiredAbilities = new Dictionary<AbilityDefinition, PlayerAbility>();
        }


        private void OnEnterWorldAbilities(Player player)
        {
            DisplayedAbilities.Clear();

            if (Main.myPlayer == player.whoAmI)
                DoTariaMod.Instance.AbilitiesUI.OnPlayerEnterWorld(this);

            foreach (AbilityDefinition ability in Hero.Abilities)
                if (ability.AlwaysShowInAbilitiesBar)
                    DisplayedAbilities.Add(ability);
        }

        private void PreUpdateAbilities()
        {
            ForAllAcquiredAbilities((a, p) => a.OnPlayerPreUpdate(this, p));

            ForAllAcquiredAbilities((a, p) =>
            {
                if (p.Cooldown > 0)
                    p.Cooldown--;
            });
        }

        private void PreUpdateMovementAbilities()
        {
            ForAllAcquiredAbilities((a, p) => a.OnPlayerPreUpdateMovement(this, p));
        }

        private void ResetEffectsAbilities()
        {
            LevelsSpentOnAbilities = 0;

            foreach (KeyValuePair<AbilityDefinition, PlayerAbility> kvp in AcquiredAbilities)
                if (kvp.Key.UnlockableAtLevel != 0 && kvp.Key.AffectsTotalAbilityLevelCount)
                    LevelsSpentOnAbilities += kvp.Value.Level;
        }
    }
}
