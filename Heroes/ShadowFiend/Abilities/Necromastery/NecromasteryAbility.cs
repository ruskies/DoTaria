using DoTaria.Abilities;
using DoTaria.Enums;
using DoTaria.Helpers;
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

        public override string GetAbilityTooltip(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) =>
            "Shadow Fiend steals the soul from units he kills, gaining bonus damage. If the killed unit is a hero, he gains an additional 11 bonus souls. On death, he releases half of them from bondage.\n\n" + 
            $"Damage per soul: {GetDamagePerSoul(dotariaPlayer, playerAbility)}\nMax souls: " +
            AbilitiesHelper.GenerateCleanSlashedString((player, ability) => GetMaxSouls(dotariaPlayer, ability), dotariaPlayer, this);


        public override void OnPlayerKilledNPC(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, NPC npc)
        {
            dotariaPlayer.Souls += 1;

            if (npc.boss)
                dotariaPlayer.Souls += 15;
        }


        public override void ModifyWeaponDamage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, Item item, ref float add, ref float mult, ref float flat)
        {
            if (item.ranged && item.ammo == 0)
                flat += AbilityDefinitionManager.Instance.Necromastery.GetExtraFlatDamage(dotariaPlayer, playerAbility);
        }


        public int GetMaxSouls(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility)
        {
            if (!dotariaPlayer.HasAbility(this))
                return 0;

            return 4 + playerAbility.Level * 8 + (dotariaPlayer.HasAghanims() ? 10 : 0);
        }

        public int GetDamagePerSoul(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 2; // TODO Add support for talents.

        public int GetExtraFlatDamage(DoTariaPlayer dotariaPlayer) => GetExtraFlatDamage(dotariaPlayer, dotariaPlayer.AcquiredAbilities[this]);
        public int GetExtraFlatDamage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility)
        {
            // TODO Add support for talent.
            int actualSouls = dotariaPlayer.Souls;
            int maxSouls = AbilityDefinitionManager.Instance.Necromastery.GetMaxSouls(dotariaPlayer, playerAbility);

            if (actualSouls > maxSouls)
                actualSouls = maxSouls;

            return actualSouls * 2;
        }


        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 0;
    }
}