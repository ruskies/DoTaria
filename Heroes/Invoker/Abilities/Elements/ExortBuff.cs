using DoTaria.Abilities;
using DoTaria.Players;
using Terraria;

namespace DoTaria.Heroes.Invoker.Abilities.Elements
{
    public sealed class ExortBuff : InvokerElementBuff
    {
        public ExortBuff() : base(AbilityDefinitionManager.Instance.Exort)
        {
        }


        public override void ExtraModifyTooltip(DoTariaPlayer dotariaPlayer, int elementCount, ref string tip, ref int rare)
        {
            tip += $"\nYour magic weapons deal an extra {ExortAbility.GetExtraDamage(dotariaPlayer, dotariaPlayer.AcquiredAbilities[InvokerElementAbility]) * elementCount} damage";
        }
    }
}