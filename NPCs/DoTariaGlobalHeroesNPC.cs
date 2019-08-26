using DoTaria.Players;
using Terraria;
using Terraria.ModLoader;

namespace DoTaria.NPCs
{
    public sealed class DoTariaGlobalHeroesNPC : GlobalNPC
    {
        public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
        {
            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(player);
            dotariaPlayer.Hero.InternalOnNPCHitByItem(dotariaPlayer, npc, damage, knockback, crit);
        }

        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            if (projectile.owner == 255)
                return;

            Player player = Main.player[projectile.owner];

            if (player.name == "")
                return;

            DoTariaPlayer dotariaPlayer = DoTariaPlayer.Get(player);
            dotariaPlayer.Hero.InternalOnNPCHitByProjectile(dotariaPlayer, npc, projectile, damage, knockback, crit);
        }


        public override bool InstancePerEntity => true;
    }
}