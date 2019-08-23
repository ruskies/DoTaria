using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.ShadowFiend.Abilities.Shadowrazes
{
    public sealed class ShadowrazeMiddleAbility : ShadowrazeAbility
    {
        public const string UNLOCALIZED_NAME = "shadowrazeMiddle";

        public ShadowrazeMiddleAbility() : base(UNLOCALIZED_NAME, "Shadowraze (Middle)", AbilitySlot.Second, 450, false)
        {
        }
    }
}
