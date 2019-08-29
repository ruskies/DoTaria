using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Helpers;
using DoTaria.Players;
using Microsoft.Xna.Framework;

namespace DoTaria.Heroes.Invoker.Abilities.Elements
{
    public sealed class QuasAbility : InvokerElementAbility
    {
        public const string UNLOCALIZED_NAME = "quas";


        public QuasAbility() : base(UNLOCALIZED_NAME, "Quas", AbilityType.Active, DamageType.None, AbilitySlot.First, Color.Blue)
        {
        }

        public override string GetAbilityTooltip(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            "Allows manipulation of ice elements. Each Quas instance provides increased health regeneration.\n\n" +
            $"HP regen per instance:\n{AbilitiesHelper.GenerateCleanSlashedString(GetExtraHealthRegeneration, dotariaPlayer, this)}";


        public override void CastElementPlayerResetEffects(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            dotariaPlayer.player.lifeRegen += (int) GetExtraHealthRegeneration(dotariaPlayer, playerAbility);

        public static float GetExtraHealthRegeneration(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => playerAbility.Level;
    }
}