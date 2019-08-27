using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.ShadowFiend.Abilities.Shadowrazes
{
    public sealed class ShadowrazeFarAbility : ShadowrazeAbility
    {
        public const string UNLOCALIZED_NAME = "shadowrazeFar";

        public ShadowrazeFarAbility() : base(UNLOCALIZED_NAME, "Shadowraze", AbilitySlot.Third,700, false)
        {
        }

        public override string GetAbilityTooltip(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            "Shadow Fiend razes the ground a longer distance away from him, dealing damage to enemy units in the area. Adds a stacking damage amplifier on the target that causes the enemy to take bonus Shadow Raze damage per stack.\n\n" + base.GetAbilityTooltip(dotariaPlayer, playerAbility);
    }
}
