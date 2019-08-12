using DoTaria.Abilities;
using DoTaria.Enums;
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


        public override void CastElementPlayerResetEffects(DoTariaPlayer player, PlayerAbility playerAbility) =>
            player.player.lifeRegen += GetExtraHealthRegeneration(playerAbility.Level);

        public static int GetExtraHealthRegeneration(int level) => 1 + 2 * (level - 1);
    }
}