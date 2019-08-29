using DoTaria.Abilities;
using DoTaria.Players;
using Terraria;

namespace DoTaria.Heroes.Invoker.Abilities.Elements
{
    public sealed class QuasBuff : InvokerElementBuff
    {
        public QuasBuff() : base(AbilityDefinitionManager.Instance.Quas)
        {
        }


        public override void ExtraModifyTooltip(DoTariaPlayer dotariaPlayer, int elementCount, ref string tip, ref int rare)
        {
            tip += $"\nYou regenerate an extra {QuasAbility.GetExtraHealthRegeneration(dotariaPlayer, dotariaPlayer.AcquiredAbilities[InvokerElementAbility]) * elementCount} life per second";
        }
    }
}