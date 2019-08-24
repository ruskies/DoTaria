using System;
using System.Collections.Generic;
using DoTaria.Abilities;
using DoTaria.Network;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        public bool HasAbility(AbilityDefinition ability) => AcquiredAbilities.ContainsKey(ability);

        public bool HasAbility(AbilityDefinition ability, int level) => HasAbility(ability) && level <= AcquiredAbilities[ability].Level;

        public void AcquireOrLevelUp(AbilityDefinition ability, bool callAbilityLeveledUp = true)
        {
            if (!HasAbility(ability))
                AcquiredAbilities.Add(ability, new PlayerAbility(ability, 1, 0));
            else
                AcquiredAbilities[ability].Level++;

            if (callAbilityLeveledUp)
                ability.InternalOnAbilityLeveledUp(this);
        }


        public PlayerAbility GetPlayerAbility(AbilityDefinition ability)
        {
            if (!HasAbility(ability))
                return null;

            return AcquiredAbilities[ability];
        }


        public bool TryActivateAbility(AbilitySlot abilitySlot)
        {
            AbilityDefinition ability = GetAbilityForSlot(abilitySlot);

            if (ability == null || !HasAbility(ability))
                return false;

            PlayerAbility playerAbility = AcquiredAbilities[ability];

            if (playerAbility.Cooldown > 0 || ability.InternalGetManaCost(this) > player.statMana)
                return false;

            if (!ability.InternalCanCastAbility(this, playerAbility))
                return false;

            if (ability.InternalCastAbility(this, playerAbility, true))
            {
                ability.OnAbilityCasted(this, playerAbility);

                if (Main.netMode == NetmodeID.MultiplayerClient && player.whoAmI == Main.myPlayer)
                    NetworkPacketManager.Instance.AbilityCasted.SendPacketToAllClients(player.whoAmI, player.whoAmI, ability.UnlocalizedName, AcquiredAbilities[ability].Cooldown);

                player.statMana -= (int)Math.Ceiling(ability.InternalGetManaCost(this));

                return true;
            }

            return false;
        }

        public AbilityDefinition GetAbilityForSlot(AbilitySlot abilitySlot)
        {
            // LINQ FANSTRAIGHTS OMEGALUL

            for (int i = 0; i < DisplayedAbilities.Count; i++)
                if (DisplayedAbilities[i].AbilitySlot == abilitySlot)
                    return DisplayedAbilities[i];

            return null;
        }


        public void ForAllAcquiredAbilities(Action<AbilityDefinition, PlayerAbility> action)
        {
            foreach (KeyValuePair<AbilityDefinition, PlayerAbility> kvp in AcquiredAbilities)
                action(kvp.Key, kvp.Value);
        }


        internal List<AbilityDefinition> DisplayedAbilities { get; private set; }

        internal Dictionary<AbilityDefinition, PlayerAbility> AcquiredAbilities { get; set; }
        
        public int LevelsSpentOnAbilities { get; private set; }
        public bool HasSpareLevels => LevelsSpentOnAbilities < Level;
    }
}
