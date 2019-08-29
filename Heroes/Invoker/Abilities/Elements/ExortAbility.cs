using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Helpers;
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

        public override string GetAbilityTooltip(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            "Allows manipulation of fire elements. Each Exort instance provides increased attack damage to magic weapons.\n" +
            $"Damage per instance: {AbilitiesHelper.GenerateCleanSlashedString(GetExtraDamage, dotariaPlayer, this)}";


        public override void CastElementModifyWeaponDamage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, Item item, ref float add, ref float mult, ref float flat)
        {
            if (item.magic)
                flat += GetExtraDamage(dotariaPlayer, playerAbility);
        }


        public static float GetExtraDamage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 2 * playerAbility.Level;


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;
    }
}
