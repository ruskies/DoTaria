using DoTaria.Abilities;
using DoTaria.Players;

namespace DoTaria.Heroes.ShadowFiend.Abilities
{
    public static class ShadowrazeDefaultMath
    {
        // TODO Add support for talents.
        public static float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 10;

        public static float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 90;
    }
}
