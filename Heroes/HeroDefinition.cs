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


        internal void OnPlayerEnterWorldStandard(DoTariaPlayer dotariaPlayer)
        {
            VerifyAndApplyBuffs(dotariaPlayer);

            OnPlayerEnterWorld(dotariaPlayer);
        }

        public virtual void OnPlayerEnterWorld(DoTariaPlayer dotariaPlayer)
        {
            VerifyAndApplyBuffs(dotariaPlayer);
        }


        public virtual void VerifyAndApplyBuffs(DoTariaPlayer dotariaPlayer) { }


        public virtual void OnPlayerDeath(DoTariaPlayer dotariaPlayer, double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) { }

        public virtual void OnPlayerKilledNPC(DoTariaPlayer dotariaPlayer, NPC npc) { }

        internal void OnPlayerPreUpdateMovementStandard(DoTariaPlayer dotariaPlayer)
        {
            VerifyAndApplyBuffs(dotariaPlayer);

            OnPlayerPreUpdateMovement(dotariaPlayer);
        }

        public virtual void OnPlayerPreUpdateMovement(DoTariaPlayer dotariaPlayer) { }


        public virtual void ModifyWeaponDamage(DoTariaPlayer dotariaPlayer, Item item, ref float add, ref float mult, ref float flat) { }


        public string UnlocalizedName { get; }

        public IReadOnlyList<AbilityDefinition> Abilities => _abilities.AsReadOnly();
    }
}
