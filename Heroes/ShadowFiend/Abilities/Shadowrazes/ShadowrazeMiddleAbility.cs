using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.ShadowFiend.Abilities.Shadowrazes
{
    public sealed class ShadowrazeMiddleAbility : ShadowrazeAbility
    {
        public const string UNLOCALIZED_NAME = "shadowrazeMiddle";

        public ShadowrazeMiddleAbility() : base(UNLOCALIZED_NAME, "Shadowraze", AbilitySlot.Second, 450, false)
        {
        }

        public override string GetAbilityTooltip(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            "Shadow Fiend razes the ground a short distance away from him, dealing damage to enemy units in the area. Adds a stacking damage amplifier on the target that causes the enemy to take bonus Shadow Raze damage per stack.\n\n" + base.GetAbilityTooltip(dotariaPlayer, playerAbility);
    }
}
