using System.Collections.Generic;
using DoTaria.Abilities;
using DoTaria.Heroes;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private HeroDefinition _hero = null;


        private void InitializeHeroes()
        {
            InitializeInvoker();
        }

        private void KillHeroes(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            Hero.OnPlayerDeath(this, damage, hitDirection, pvp, damageSource);
        }


        private void OnEnterWorldHeroes(Player player)
        {
            Hero.InternalOnPlayerEnterWorld(player.GetModPlayer<DoTariaPlayer>());
        }

        private void OnKilledNPCHeroes(NPC npc)
        {
            Hero.OnPlayerKilledNPC(this, npc);
        }


        private void ModifyWeaponDamageHeroes(Item item, ref float add, ref float mult, ref float flat)
        {
            Hero.ModifyWeaponDamage(this, item, ref add, ref mult, ref flat);
        }


        private void PostHurtHeroes(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            Hero.OnPlayerPostHurt(this, pvp, quiet, damage, hitDirection, crit);
        }

        private bool PreHurtHeroes(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (!Hero.OnPlayerPreHurt(this, pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource))
                return false;

            return true;
        }


        private void PreUpdateMovementHeroes()
        {
            Hero.InternalOnPlayerPreUpdateMovement(this);
        }


        private void ResetEffectsHeroes()
        {
            Hero.OnPlayerResetEffects(this);
        }


        public HeroDefinition Hero
        {
            get
            {
                if (_hero == null)
                    _hero = HeroDefinitionManager.Instance.Abaddon;

                return _hero;
            }

            set => _hero = value;
        }

        public bool HeroSelected { get; internal set; }
    }
}
