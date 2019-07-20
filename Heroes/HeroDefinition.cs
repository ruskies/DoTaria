using DoTaria.Abilities;
using DoTaria.Commons;
using DoTaria.Players;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;

namespace DoTaria.Heroes
{
    public abstract class HeroDefinition : IHasUnlocalizedName
    {
        private readonly List<AbilityDefinition> _abilities;

        public HeroDefinition(string unlocalizedName, params AbilityDefinition[] abilities)
        {
            UnlocalizedName = unlocalizedName;

            _abilities = new List<AbilityDefinition>(abilities);
        }


        public virtual void OnPlayerEnterWorld(DoTariaPlayer dotarriaPlayer)
        {
            ApplyInitialBuffs(dotarriaPlayer);
        }


        public virtual void ApplyInitialBuffs(DoTariaPlayer dotarriaPlayer) { }


        public virtual void OnPlayerDeath(DoTariaPlayer dotarriaPlayer, double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) { }

        public virtual void OnPlayerKilledNPC(DoTariaPlayer dotarriaPlayer, NPC npc) { }


        public virtual void ModifyWeaponDamage(DoTariaPlayer dotarriaPlayer, Item item, ref float add, ref float mult, ref float flat) { }

        /**
         * int extraDamage = dotarriaPlayer.Souls * 2;

            player.meleeDamage += extraDamage;
            player.rangedDamage += extraDamage;
         */

        public string UnlocalizedName { get; }

        public IReadOnlyList<AbilityDefinition> Abilities => _abilities.AsReadOnly();
    }
}
