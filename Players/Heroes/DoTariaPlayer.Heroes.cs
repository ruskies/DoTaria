using DoTaria.Heroes;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private void KillHeroes(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            Hero.OnPlayerDeath(this, damage, hitDirection, pvp, damageSource);
        }


        private void OnEnterWorldHeroes(DoTariaPlayer dotariaPlayer)
        {
            Hero.OnPlayerEnterWorldStandard(this);
        }

        private void OnKilledNPCHeroes(NPC npc)
        {
            Hero.OnPlayerKilledNPC(this, npc);
        }


        private bool PreHurtHeroes(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (!Hero.OnPlayerPreHurt(this, pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource))
                return false;

            return true;
        }

        private void PreUpdateMovementHeroes()
        {
            Hero.OnPlayerPreUpdateMovementStandard(this);
        }


        private void ModifyWeaponDamageHeroes(Item item, ref float add, ref float mult, ref float flat)
        {
            Hero.ModifyWeaponDamage(this, item, ref add, ref mult, ref flat);
        }


        public HeroDefinition Hero { get; private set; } = HeroDefinitionManager.Instance.ShadowFiend;
    }
}
