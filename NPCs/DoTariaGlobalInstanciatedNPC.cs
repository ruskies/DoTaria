using DoTaria.Players;
using Terraria;
using Terraria.ModLoader;

namespace DoTaria.NPCs
{
    public sealed class DoTariaGlobalInstanciatedNPC : GlobalNPC
    {
        public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
        {
            DoTariaPlayer.Get(player).OnHitNPCWithItem(npc, player, item, damage, knockback, crit);
        }

        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            if (projectile.owner == 255)
                return;

            Player player = Main.player[projectile.owner];

            if (player.name == "")
                return;

            DoTariaPlayer.Get(player).OnHitNPCWithProjectile(npc, projectile, damage, knockback, crit);
        }


        public override bool InstancePerEntity => true;
    }
}