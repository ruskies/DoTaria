using DoTaria.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private void KillHeroes(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            Hero.OnPlayerDeath(this, damage, hitDirection, pvp, damageSource);
        }


        private void OnEnterWorldHeroes(DoTariaPlayer dotarriaPlayer)
        {
            Hero.OnPlayerEnterWorld(this);
        }

        private void OnPlayerKilledNPCHeroes(NPC npc)
        {
            Hero.OnPlayerKilledNPC(this, npc);
        }


        private void ModifyWeaponDamageHeroes(Item item, ref float add, ref float mult, ref float flat)
        {
            Hero.ModifyWeaponDamage(this, item, ref add, ref mult, ref flat);
        }


        public HeroDefinition Hero { get; private set; } = HeroDefinitionManager.Instance.ShadowFiend;
    }
}
