using DoTaria.Abilities;
using DoTaria.Commons;
using DoTaria.Enums;
using DoTaria.Helpers;
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

        public override string GetAbilityTooltip(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            "Allows manipulation of storm elements. Each Wex instance provides increased magic regen and movement speed.\n\n" +
            $"Attack speed per instance:\nNOT YET DONE\n" + // {AbilitiesHelper.GenerateCleanSlashedString()}
            $"(Temp) MP regen per instance (%):\n{AbilitiesHelper.GenerateCleanSlashedString((player, ability) => GetManaRegenerationPercentage(player, ability) * 100, dotariaPlayer, this)}\n" + 
            $"Move speed per instance:\n{AbilitiesHelper.GenerateCleanSlashedString((player, ability) => GetExtraMoveSpeedPercentage(player, ability) * 100, dotariaPlayer, this)}";


        public override void CastElementPreUpdateMovement(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 
            dotariaPlayer.player.moveSpeed += GetExtraMoveSpeed(dotariaPlayer, playerAbility);

        public override void CastElementPlayerResetEffects(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            dotariaPlayer.BufferedManaRegen += GetManaRegeneration(dotariaPlayer, playerAbility) / DoTariaMath.TICKS_PER_SECOND;


        public static float GetExtraMoveSpeedPercentage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0.01f * playerAbility.Level;
        public static float GetExtraMoveSpeed(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 
            dotariaPlayer.player.moveSpeed * GetExtraMoveSpeedPercentage(dotariaPlayer, playerAbility);


        public static float GetManaRegenerationPercentage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            0.02f + playerAbility.Level * 0.005f;
        public static float GetManaRegeneration(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            dotariaPlayer.player.statManaMax2 * GetManaRegenerationPercentage(dotariaPlayer, playerAbility);
    }
}  