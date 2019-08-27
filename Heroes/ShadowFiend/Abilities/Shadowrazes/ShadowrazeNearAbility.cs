using DoTaria.Abilities;
using DoTaria.Players;

namespace DoTaria.Heroes.ShadowFiend.Abilities.Shadowrazes
{
    public sealed class ShadowrazeNearAbility : ShadowrazeAbility
    {
        public const string UNLOCALIZED_NAME = "shadowrazeNear";

        public ShadowrazeNearAbility() : base(UNLOCALIZED_NAME, "Shadowraze", AbilitySlot.First, 200, true)
        {
        }

        public override string GetAbilityTooltip(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            "Shadow Fiend razes the ground directly in front of him, dealing damage to enemy units in the area. Adds a stacking damage amplifier on the target that causes the enemy to take bonus Shadow Raze damage per stack.\n\n" + base.GetAbilityTooltip(dotariaPlayer, playerAbility);
    }
}
