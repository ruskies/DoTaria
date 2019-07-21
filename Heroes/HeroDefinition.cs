using DoTaria.Abilities;
using DoTaria.Commons;
using DoTaria.Players;
using System.Collections.Generic;
using DoTaria.Attribute;
using Terraria;
using Terraria.DataStructures;

namespace DoTaria.Heroes
{
    public abstract class HeroDefinition : IHasUnlocalizedName
    {
        public const string UNLOCALIZED_NAME_PREFIX = "heroes.";

        private readonly List<AbilityDefinition> _abilities;

        protected HeroDefinition(string unlocalizedName, Attributes baseAttributes, Attributes gainPerLevel, params AbilityDefinition[] abilities)
        {
            UnlocalizedName = unlocalizedName;

            BaseAttributes = baseAttributes;
            GainPerLevel = gainPerLevel;

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


        /// <summary></summary>
        /// <param name="dotariaPlayer"></param>
        /// <param name="pvp"></param>
        /// <param name="quiet"></param>
        /// <param name="damage"></param>
        /// <param name="hitDirection"></param>
        /// <param name="crit"></param>
        /// <param name="customDamage"></param>
        /// <param name="playSound"></param>
        /// <param name="genGore"></param>
        /// <param name="damageSource"></param>
        /// <returns>Return false to stop the player from taking damage. Default returns true.</returns>
        public virtual bool OnPlayerPreHurt(DoTariaPlayer dotariaPlayer, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) => true;


        internal void OnPlayerPreUpdateMovementStandard(DoTariaPlayer dotariaPlayer)
        {
            VerifyAndApplyBuffs(dotariaPlayer);

            OnPlayerPreUpdateMovement(dotariaPlayer);
        }

        public virtual void OnPlayerPreUpdateMovement(DoTariaPlayer dotariaPlayer) { }


        public virtual void ModifyWeaponDamage(DoTariaPlayer dotariaPlayer, Item item, ref float add, ref float mult, ref float flat) { }


        public string UnlocalizedName { get; }

        public Attributes BaseAttributes { get; }
        public Attributes GainPerLevel { get; }

        public IReadOnlyList<AbilityDefinition> Abilities => _abilities.AsReadOnly();
    }
}
