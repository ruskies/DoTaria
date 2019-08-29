using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Heroes.Invoker.Abilities.InvokableAbilities;
using DoTaria.Players;
using Terraria;

namespace DoTaria.Heroes.Invoker.Abilities
{
    public sealed class InvokeAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = "invoke";


        public InvokeAbility() : base(UNLOCALIZED_NAME, "Invoke", 
            AbilityType.Active, AbilityTargetType.NoTarget, AbilityTargetFaction.Self, AbilityTargetUnitType.None,
            DamageType.None, AbilitySlot.Ultimate, 0, 1)
        {
        }

        public override string GetAbilityTooltip(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            "Combines the properties of the elements currently being manipulated to create a new spell for Invoker to use. Will cast the spell combination if the player has enough mana and if the spell is on cooldown.\n\nMax spells: 2";


        public override bool CastAbility(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, bool casterIsLocalPlayer)
        {
            if (!casterIsLocalPlayer)
                return true;

            InvokableAbility invokableAbility = InvokableAbilities.InvokableAbilities.GetAbilityForCombination(dotariaPlayer.currentInvokerElements.ToArray());

            if (invokableAbility == null)
                return false;

            return dotariaPlayer.TryActivateAbility(invokableAbility);
        }


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => dotariaPlayer.HasAghanims() ? 2 : 6;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;
    }
}