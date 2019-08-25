using DoTaria.Abilities;

namespace DoTaria.Heroes.ShadowFiend.Abilities.Shadowrazes
{
    public sealed class ShadowrazeNearAbility : ShadowrazeAbility
    {
        public const string UNLOCALIZED_NAME = "shadowrazeNear";

        public ShadowrazeNearAbility() : base(UNLOCALIZED_NAME, "Shadowraze (Near)", AbilitySlot.First, 200, true)
        {
        }
    }
}
