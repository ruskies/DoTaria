
using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Helpers;
using DoTaria.Players;
using Microsoft.Xna.Framework;
using Terraria;

namespace DoTaria.Heroes.Abaddon.Abilities.MistCoil
{
    public sealed class MistCoilAbility : AbilityDefinition
    {
        private const string UNLOCALIZED_NAME = AbaddonHero.UNLOCALIZED_NAME + ".mistCoil";

        public MistCoilAbility() : base(UNLOCALIZED_NAME, "Mist Coil", 
            AbilityType.Active, AbilityTargetType.TargetUnit, AbilityTargetFaction.Allies & AbilityTargetFaction.Enemies, AbilityTargetUnitType.Living,
            DamageType.Pure, AbilitySlot.First, 1, 4)
        {
        }


        public override bool CastAbility(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, bool casterIsLocalPlayer, float calculatedDamage)
        {
            EntitiesHelper.GetLocalHoveredEntity(out Player player, out NPC npc);

            if (player == null && npc == null)
                return false;

            if (casterIsLocalPlayer)
            {
                MistCoilProjectile mistCoil = Main.projectile[Projectile.NewProjectile(dotariaPlayer.player.position, Vector2.Zero, dotariaPlayer.mod.ProjectileType<MistCoilProjectile>(), (int) calculatedDamage, 0f, dotariaPlayer.player.whoAmI)].modProjectile as MistCoilProjectile;

                if (player != null)
                    mistCoil.homeOntoPlayer = player;

                if (npc != null)
                    mistCoil.homeOntoNPC = npc;
            }

            return true;
        }


        // TODO Add support for talents.
        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 4.5f;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 50;
    }
}
