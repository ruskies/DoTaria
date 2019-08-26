using System.Collections.Generic;
using DoTaria.Abilities;
using Terraria;
using Terraria.ModLoader;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer
    {
        private void InitializeAbilities()
        {
            DisplayedAbilities = new List<AbilityDefinition>();
            AcquiredAbilities = new Dictionary<AbilityDefinition, PlayerAbility>();
        }


        private void ModifyDrawLayersAbilities(List<PlayerLayer> layers)
        {
            foreach (KeyValuePair<AbilityDefinition, PlayerAbility> kvp in AcquiredAbilities)
                kvp.Key.ModifyPlayerDrawLayers(this, kvp.Value, layers);
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
                bool hadCooldown = false;

                if (p.Cooldown > 0)
                {
                    hadCooldown = true;
                    p.Cooldown--;
                }

                if (hadCooldown && p.Cooldown == 0 && a.AbilityType == AbilityType.Passive)
                    a.InternalOnAbilityCooldownExpired(this, p);
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
