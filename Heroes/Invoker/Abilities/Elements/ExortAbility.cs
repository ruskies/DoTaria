using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;
using Microsoft.Xna.Framework;
using Terraria;

namespace DoTaria.Heroes.Invoker.Abilities.Elements
{
    public sealed class ExortAbility : InvokerElementAbility
    {
        public const string UNLOCALIZED_NAME = "exort";


        public ExortAbility() : base(UNLOCALIZED_NAME, "Exort", AbilityType.Active, DamageType.None, AbilitySlot.Third, Color.Orange)
        {
        }


        public override void CastElementModifyWeaponDamage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, Item item, ref float add, ref float mult, ref float flat)
        {
            if (item.melee || item.ranged)
                flat += GetExtraDamage(playerAbility.Level);
        }


        public static int GetExtraDamage(int level) => 2 + 4 * (level - 1);


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;
    }
}
