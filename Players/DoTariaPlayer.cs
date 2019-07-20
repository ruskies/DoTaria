using DoTaria.Dusts;
using DoTaria.Extensions;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        public static DoTariaPlayer Get(Player player) => player.GetModPlayer<DoTariaPlayer>();


        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            KillHeroes(damage, hitDirection, pvp, damageSource);
        }


        public override void OnEnterWorld(Player player)
        {
            OnEnterWorldHeroes(this);
        }

        public void OnKilledNPC(NPC npc)
        {
            OnKilledNPCHeroes(npc);
        }


        public override void PostUpdate()
        {
            if (!player.dead)
            {
                List<ISpawnDustOnPlayerPostUpdate> sdoppu = player.GetItemsByType<ISpawnDustOnPlayerPostUpdate>(armor: true, armorSocial: true, accessories: true, accessoriesSocial: true);

                for (int i = 0; i < sdoppu.Count; i++)
                    sdoppu[i].SpawnDustOnPlayerPostUpdate(this);
            }
        }

        public override void PreUpdateMovement()
        {
            PreUpdateMovementHeroes();
            PreUpdateMovementAghanims();
        }


        public override void ModifyWeaponDamage(Item item, ref float add, ref float mult, ref float flat)
        {
            ModifyWeaponDamageHeroes(item, ref add, ref mult, ref flat);
        }
    }
}
