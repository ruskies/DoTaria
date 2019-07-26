using System;
using DoTaria.Commons;
using DoTaria.Heroes;
using DoTaria.Statistic;
using Terraria.ModLoader;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private float _bufferedManaRegen = 0;

        private void ResetEffectsStatistics()
        {
            Statistics = Statistics.FromAttributes(Attributes);

            if (mod.GetConfig<DoTariaGlobalConfiguration>().EnableModCompatibility)
            {
                player.statLifeMax2 += (int)Math.Ceiling((Hero.BaseStatistics.TerrariaHealth + Statistics.TerrariaHealth) * (player.statLifeMax / MAX_VANILLA_HEALTH));
                player.lifeRegen += (int)Math.Ceiling(Hero.BaseStatistics.TerrariaHealthRegeneration + Statistics.TerrariaHealthRegeneration);

                player.statDefense += (int)Math.Ceiling(Hero.BaseStatistics.Armor + Statistics.Armor);
                player.moveSpeed += (int)Math.Ceiling((Hero.BaseMovementSpeed / HeroDefinitionManager.Instance.AverageBaseMovementSpeed) * (Hero.BaseStatistics.MoveSpeedAmplification + Statistics.MoveSpeedAmplification));

                player.statManaMax2 += (int)Math.Ceiling((Hero.BaseStatistics.TerrariaMana + Statistics.TerrariaMana) * (player.statManaMax / MAX_VANILLA_MANA));
                player.manaRegen += (int)(Math.Ceiling(Hero.BaseStatistics.TerrariaManaRegeneration + Statistics.TerrariaManaRegeneration) / DoTariaMath.TICKS_PER_SECOND);
                SpellAmplification = 1 + (int)(Hero.BaseStatistics.SpellDamageAmplification + Statistics.SpellDamageAmplification);
            }
            else // For when we have compatibility option in config.
            {
                player.statLifeMax2 = (int)Math.Ceiling(Hero.BaseStatistics.TerrariaHealth + Statistics.TerrariaHealth * (player.statLifeMax / MAX_VANILLA_HEALTH));
                player.lifeRegen = (int)Math.Ceiling(Hero.BaseStatistics.TerrariaHealthRegeneration + Statistics.TerrariaHealthRegeneration);

                player.statDefense = (int)Math.Ceiling(Hero.BaseStatistics.Armor + Statistics.Armor);
                player.moveSpeed = (int)Math.Ceiling((Hero.BaseMovementSpeed / HeroDefinitionManager.Instance.AverageBaseMovementSpeed) * (Hero.BaseStatistics.MoveSpeedAmplification + Statistics.MoveSpeedAmplification));

                player.statManaMax2 = (int)Math.Ceiling((Hero.BaseStatistics.TerrariaMana + Statistics.TerrariaMana) * (player.statManaMax / MAX_VANILLA_MANA));

                player.manaRegen = 0;
                player.manaRegenDelay = 999; // Ahah in Shenzen IO the max number for ACC is 999 ;) :wonk:

                SpellAmplification = 1 + (int)(Hero.BaseStatistics.SpellDamageAmplification + Statistics.SpellDamageAmplification);

                _bufferedManaRegen += (Hero.BaseStatistics.TerrariaManaRegeneration + Statistics.TerrariaManaRegeneration) / DoTariaMath.TICKS_PER_SECOND;

                if (_bufferedManaRegen >= 1)
                {
                    float toClip = _bufferedManaRegen % 1;
                    player.statMana += (int) (_bufferedManaRegen - toClip);

                    _bufferedManaRegen = toClip;
                }
            }
        }


        public Statistics Statistics { get; private set; }


        public float SpellAmplification { get; private set; }
    }
}
