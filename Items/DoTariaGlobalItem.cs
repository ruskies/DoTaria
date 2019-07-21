using DoTaria.Attribute;
using DoTaria.Players;
using Terraria;
using Terraria.ModLoader;

namespace DoTaria.Items
{
    public sealed class DoTariaGlobalItem : GlobalItem
    {
        private const float MAX_ATTACK_SPEED = 700f;

        public override float UseTimeMultiplier(Item item, Player player)
        {
            if (item.melee || item.ranged)
            {
                DoTariaPlayer dotariaPlayer = player.GetModPlayer<DoTariaPlayer>();

                return 1 - Attributes.AttackSpeedFromAgility(dotariaPlayer.Hero.BaseAttributes.Agility) / MAX_ATTACK_SPEED;
            }

            return 1f;
        }
    }
}