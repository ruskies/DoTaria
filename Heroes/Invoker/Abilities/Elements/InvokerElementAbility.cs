using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;
using Microsoft.Xna.Framework;
using Terraria;

namespace DoTaria.Heroes.Invoker.Abilities.Elements
{
    public abstract class InvokerElementAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME_PREFIX = InvokerHero.UNLOCALIZED_NAME + ".";


        protected InvokerElementAbility(string unlocalizedName, string displayName, AbilityType abilityType, DamageType damageType, AbilitySlot abilitySlot, Color abilityColor) : 
            base(UNLOCALIZED_NAME_PREFIX + unlocalizedName, displayName, abilityType, AbilityTargetType.NoTarget, AbilityTargetFaction.Self, AbilityTargetUnitType.None, damageType, abilitySlot, 1, 7)
        {
            AbilityColor = abilityColor;
        }


        public override bool CastAbility(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, bool casterIsLocalPlayer)
        {
            CombatText.NewText(new Rectangle((int) dotariaPlayer.player.position.X, (int) dotariaPlayer.player.position.Y,
                (int) (dotariaPlayer.player.width), (int) (dotariaPlayer.player.height)), AbilityColor, DisplayName);

            dotariaPlayer.CastInvokerElement(this);
            return true;
        }


        public virtual void CastElementPlayerResetEffects(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) { }

        public virtual void CastElementModifyWeaponDamage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, Item item, ref float add, ref float mult, ref float flat) { }

        public virtual void CastElementPreUpdateMovement(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) { }


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;


        public Color AbilityColor { get; }
    }
}