using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;
using Microsoft.Xna.Framework;

namespace DoTaria.Heroes.Invoker.Abilities.Elements
{
    public sealed class WexAbility : InvokerElementAbility
    {
        public const string UNLOCALIZED_NAME = "wex";


        public WexAbility() : base(UNLOCALIZED_NAME, "Wex", AbilityType.Active, DamageType.None, AbilitySlot.Second, Color.Purple) 
        {
        }


        public override void CastElementPreUpdateMovement(DoTariaPlayer player, PlayerAbility playerAbility) => player.player.moveSpeed += GetExtraMoveSpeed(player.player.moveSpeed, playerAbility.Level);

        public override void CastElementPlayerResetEffects(DoTariaPlayer player, PlayerAbility playerAbility)
        {
            player.BufferedManaRegen += player.player.statManaMax2 * (0.02f + playerAbility.Level * 0.005f);
        }


        public static float GetExtraMoveSpeedPercentage(int level) => 0.01f * level;
        public static float GetExtraMoveSpeed(float moveSpeed, int level) => moveSpeed * GetExtraMoveSpeedPercentage(level);
    }
}  