using System.Collections.Generic;
using DoTaria.Abilities;
using Terraria;
using Terraria.DataStructures;
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

        private void ModifyWeaponDamageAbilities(Item item, ref float add, ref float mult, ref float flat)
        {
            foreach (KeyValuePair<AbilityDefinition, PlayerAbility> kvp in this.AcquiredAbilities)
                kvp.Key.ModifyWeaponDamage(this, kvp.Value, item, ref add, ref mult, ref flat);
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

        private void OnKilledNPCAbilities(NPC npc) =>
            ForAllAcquiredAbilities((a, p) => a.OnPlayerKilledNPC(this, p, npc));

        private void OnHitNPCWithItemAbilities(NPC npc, Player player, Item item, int damage, float knockback, bool crit) =>
            ForAllAcquiredAbilities((a, p) => a.OnPlayerHitNPCWithItem(this, p, npc, player, item, damage, knockback, crit));

        private void OnHitNPCWithProjectileAbilities(NPC npc, Projectile projectile, int damage, float knockback, bool crit) =>
            ForAllAcquiredAbilities((a, p) => a.OnPlayerHitNPCWithProjectile(this, p, npc, projectile, damage, knockback, crit));


        // 
        private bool PreHurtAbilities(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            foreach (KeyValuePair<AbilityDefinition, PlayerAbility> kvp in AcquiredAbilities)
                if (!kvp.Key.OnPlayerPreHurt(this, kvp.Value, pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource))
                    return false;

            return true;
        }

        private void PostHurtAbilities(bool pvp, bool quiet, double damage, int hitDirection, bool crit) =>
            ForAllAcquiredAbilities((a, p) => a.OnPlayerPostHurt(this, p, pvp, quiet, damage, hitDirection, crit));


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
