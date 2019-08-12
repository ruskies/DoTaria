using DoTaria.Buffs;
using DoTaria.Players;
using Terraria;

namespace DoTaria.Heroes.Invoker.Abilities.Elements
{
    public abstract class InvokerElementBuff : DoTariaBuff
    {
        protected InvokerElementBuff(InvokerElementAbility invokerElementAbility) : base(invokerElementAbility.DisplayName + " Element", "", true, false, false, false)
        {
            InvokerElementAbility = invokerElementAbility;
        }


        public override void ModifyBuffTip(ref string tip, ref int rare)
        {
            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(Main.LocalPlayer);
            int elementCount = dotariaPlayer.CountInvokerElement(InvokerElementAbility);

            tip += $"You currently have {elementCount} {InvokerElementAbility.DisplayName} element(s)";

            ExtraModifyTooltip(dotariaPlayer, elementCount, ref tip, ref rare);
        }

        public virtual void ExtraModifyTooltip(DoTariaPlayer dotariaPlayer, int elementCount, ref string tip, ref int rare) { }


        public InvokerElementAbility InvokerElementAbility { get; }
    }
}