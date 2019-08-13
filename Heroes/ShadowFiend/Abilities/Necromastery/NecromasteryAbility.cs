using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;

namespace DoTaria.Heroes.ShadowFiend.Abilities.Necromastery
{
    public sealed class NecromasteryAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = ShadowFiendHero.UNLOCALIZED_NAME + "." + "necromastery";

        public NecromasteryAbility() : base(UNLOCALIZED_NAME, "Necromastery", AbilityType.Passive, DamageType.Physical, AbilitySlot.Fourth, 1, 4)
        {
        }


        public int GetMaxSouls(DoTariaPlayer dotariaPlayer)
        {
            if (!dotariaPlayer.HasAbility(this))
                return 0;

            return 4 + dotariaPlayer.AcquiredAbilities[this].Level * 8 + (dotariaPlayer.HasAghanims() ? 10 : 0);
        }

        public int GetExtraFlatDamage(DoTariaPlayer dotariaPlayer)
        {
            // TODO Add support for talent.
            int actualSouls = dotariaPlayer.Souls;
            int maxSouls = AbilityDefinitionManager.Instance.Necromastery.GetMaxSouls(dotariaPlayer);

            if (actualSouls > maxSouls)
                actualSouls = maxSouls;

            return actualSouls * 2;
        }


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;
    }
}