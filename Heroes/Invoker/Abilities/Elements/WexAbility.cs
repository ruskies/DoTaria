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


        public static float GetExtraMoveSpeedPercentage(int level) => 0.01f * level;
        public static float GetExtraMoveSpeed(float moveSpeed, int level) => moveSpeed * GetExtraMoveSpeedPercentage(level);
    }
}  