using DoTaria.Abilities;
using DoTaria.Attribute;
using DoTaria.Players;
using Terraria.DataStructures;

namespace DoTaria.Heroes.Abaddon
{
    public sealed class AbaddonHero : HeroDefinition
    {
        public const string UNLOCALIZED_NAME = HeroDefinition.UNLOCALIZED_NAME_PREFIX + "abaddon";

        public AbaddonHero() : base(UNLOCALIZED_NAME, new Attributes(23, 23, 21), new Attributes(3, 1.5f, 2),
            AbilityDefinitionManager.Instance.BorrowedTime)
        {
        }

        public override bool OnPlayerPreHurt(DoTariaPlayer dotariaPlayer, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            
        }
    }
}
