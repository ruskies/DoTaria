using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.NPCs;
using DoTaria.Players;
using Terraria;

namespace DoTaria.Heroes.Abaddon.Abilities.CurseOfAvernus
{
    public sealed class CurseofAvernusAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = AbaddonHero.UNLOCALIZED_NAME + ".curseOfAvernus";

        public CurseofAvernusAbility() : base(UNLOCALIZED_NAME, "Curse of Avernus", AbilityType.Passive, 
            AbilityTargetType.NoTarget, AbilityTargetFaction.Self & AbilityTargetFaction.Allies & AbilityTargetFaction.Enemies, AbilityTargetUnitType.Everything,
            DamageType.None, AbilitySlot.Third, 1, 4)
        {
        }


        public override void OnPlayerHitNPCWithItem(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, NPC npc, Player player, Item item, int damage, float knockback, bool crit)
        {
            if (!item.melee) return;

            //npc.GetGlobalNPC<DoTariaGlobalInstanciatedNPC>().AddCurseofAvernus();
        }


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;
    }
}