using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.ShadowFiend.Abilities.Shadowrazes
{
    public sealed class ShadowrazeFarAbility : ShadowrazeAbility
    {
        public const string UNLOCALIZED_NAME = "shadowrazeFar";

        public ShadowrazeFarAbility() : base(UNLOCALIZED_NAME, "Shadowraze (Far)", AbilitySlot.Third,700)
        {
        }
    }
}
