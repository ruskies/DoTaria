using System;

namespace DoTaria.Abilities
{
    [Flags]
    public enum AbilityTargetFaction
    {
        Self = 1 << 0,
        Allies = 1 << 1,
        Enemies = 1 << 2
    }
}