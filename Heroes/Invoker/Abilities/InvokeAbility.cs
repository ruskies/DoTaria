using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.Invoker.Abilities
{
    public sealed class InvokeAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = "invoke";


        public InvokeAbility() : base(UNLOCALIZED_NAME, "Invoke", AbilityType.Active, AbilityTargetType.NoTarget, AbilityTargetFaction.Self, DamageType.None, AbilitySlot.Ultimate, 0, 1)
        {
        }


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => dotariaPlayer.HasAghanims() ? 2 : 6;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;
    }
}