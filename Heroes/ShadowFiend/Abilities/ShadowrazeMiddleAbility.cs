using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.ShadowFiend.Abilities
{
    public sealed class ShadowrazeMiddleAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = "shadowrazeMiddle";

        public ShadowrazeMiddleAbility() : base(ShadowFiendHero.UNLOCALIZED_NAME + '.' + UNLOCALIZED_NAME, "Shadowraze (Middle)", AbilityType.Active, DamageType.Magical, AbilitySlot.Second, 4)
        {
        }


        // TODO Add support for talents.
        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => ShadowrazeDefaultMath.GetCooldown(dotariaPlayer, playerAbility);

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => ShadowrazeDefaultMath.GetManaCost(dotariaPlayer, playerAbility);
    }
}
