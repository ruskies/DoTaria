using DoTaria.Abilities;
using DoTaria.Players;
using Terraria;

namespace DoTaria.Heroes.Invoker.Abilities.Elements
{
    public sealed class WexBuff : InvokerElementBuff
    {
        public WexBuff() : base(AbilityDefinitionManager.Instance.Wex)
        {
        }


        public override void ExtraModifyTooltip(DoTariaPlayer dotariaPlayer, int elementCount, ref string tip, ref int rare)
        {
            tip += $"\nYou move {WexAbility.GetExtraMoveSpeedPercentage(dotariaPlayer.AcquiredAbilities[InvokerElementAbility].Level) * 100 * elementCount}% faster";
        }
    }
}