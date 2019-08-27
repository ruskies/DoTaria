using System;

namespace DoTaria.Abilities
{
    [Flags]
    public enum AbilityTargetUnitType
    {
        None = 0,
        Heroes = 1 << 0,
        Units = 1 << 1,
        Towers = 1 << 2,
        Living = Units | Heroes,
        Everything = Towers | Living
    }
}