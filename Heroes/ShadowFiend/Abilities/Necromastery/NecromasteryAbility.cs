using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Players;
using Terraria;

namespace DoTaria.Heroes.ShadowFiend.Abilities.Necromastery
{
    public sealed class NecromasteryAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME = ShadowFiendHero.UNLOCALIZED_NAME + ".necromastery";

        public NecromasteryAbility() : base(UNLOCALIZED_NAME, "Necromastery", 
            AbilityType.Passive, AbilityTargetType.NoTarget, AbilityTargetFaction.Self, AbilityTargetUnitType.None,
            DamageType.Physical, AbilitySlot.Fourth, 1, 4)
        {
        }


        public override void OnPlayerKilledNPC(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, NPC npc)
        {
            dotariaPlayer.Souls += 1;

            if (npc.boss)
                dotariaPlayer.Souls += 15;
        }


        public override void ModifyWeaponDamage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, Item item, ref float add, ref float mult, ref float flat)
        {
            if (item.ranged && item.ammo == 0)
                flat += AbilityDefinitionManager.Instance.Necromastery.GetExtraFlatDamage(dotariaPlayer);
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