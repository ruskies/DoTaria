using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.Abaddon.Abilities.CurseOfAvernus
{
    public sealed class CurseOfAvernusAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = AbaddonHero.UNLOCALIZED_NAME + ".curseOfAvernus";

        public CurseOfAvernusAbility() : base(UNLOCALIZED_NAME, "Curse of Avernus", AbilityType.Passive, 
            AbilityTargetType.NoTarget, AbilityTargetFaction.Self & AbilityTargetFaction.Allies & AbilityTargetFaction.Enemies, AbilityTargetUnitType.Everything,
            DamageType.None, AbilitySlot.Third, 1, 4)
        {
        }


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;
    }
}