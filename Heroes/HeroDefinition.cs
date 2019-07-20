using DoTarria.Abilities;
using DoTarria.Commons;
using DoTarria.Players;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;

namespace DoTarria.Heroes
{
    public abstract class HeroDefinition : IHasUnlocalizedName
    {
        private readonly List<AbilityDefinition> _abilities;

        public HeroDefinition(string unlocalizedName, params AbilityDefinition[] abilities)
        {
            UnlocalizedName = unlocalizedName;

            _abilities = new List<AbilityDefinition>(abilities);
        }


        public virtual void OnPlayerEnterWorld(DoTarriaPlayer dotarriaPlayer)
        {
            ApplyInitialBuffs(dotarriaPlayer);
        }


        public virtual void ApplyInitialBuffs(DoTarriaPlayer dotarriaPlayer) { }


        public virtual void OnPlayerDeath(DoTarriaPlayer dotarriaPlayer, double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) { }

        public virtual void OnPlayerKilledNPC(DoTarriaPlayer dotarriaPlayer, NPC npc) { }


        public virtual void ModifyWeaponDamage(DoTarriaPlayer dotarriaPlayer, Item item, ref float add, ref float mult, ref float flat) { }

        /**
         * int extraDamage = dotarriaPlayer.Souls * 2;

            player.meleeDamage += extraDamage;
            player.rangedDamage += extraDamage;
         */

        public string UnlocalizedName { get; }

        public IReadOnlyList<AbilityDefinition> Abilities => _abilities.AsReadOnly();
    }
}
