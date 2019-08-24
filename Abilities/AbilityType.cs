using System;

namespace DoTaria.Abilities
{
    [Flags]
    public enum AbilityType : byte
    {
        None = 0,
        Passive = 1 << 0,
        Active = 1 << 1,
        PassiveActive = Passive & Active
    }
}