using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Extensions;
using DoTaria.Players;
using Microsoft.Xna.Framework;
using Terraria;

namespace DoTaria.Heroes.ShadowFiend.Abilities.Shadowrazes
{
    public sealed class ShadowrazeNearAbility : ShadowrazeAbility
    {
        public const string UNLOCALIZED_NAME = "shadowrazeNear";

        public ShadowrazeNearAbility() : base(UNLOCALIZED_NAME, "Shadowraze (Near)", AbilitySlot.First, 200)
        {
        }
    }
}
