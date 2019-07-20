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
            OnPlayerKilledNPCHeroes(npc);
        }


        public override void ModifyWeaponDamage(Item item, ref float add, ref float mult, ref float flat)
        {
            ModifyWeaponDamageHeroes(item, ref add, ref mult, ref flat);
        }
    }
}
