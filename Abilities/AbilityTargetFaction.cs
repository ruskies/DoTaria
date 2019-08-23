using System;

namespace DoTaria.Abilities
{
    [Flags]
    public enum AbilityTargetFaction
    {
        Self = 1 << 0,
        Enemies = 1 << 1,
        Allies = 1 << 2,
    }
}