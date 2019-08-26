using DoTaria.Abilities;
using DoTaria.Commons;
using DoTaria.Dusts.Heroes.ShadowFiend.Default;
using DoTaria.Enums;
using DoTaria.Extensions;
using DoTaria.Players;
using DoTaria.Skins.ShadowFiend.Default;
using DoTaria.Statistic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace DoTaria.Heroes.ShadowFiend.Abilities.Shadowrazes
{
    public abstract class ShadowrazeAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME_PREFIX = ShadowFiendHero.UNLOCALIZED_NAME + ".";

        public static readonly AbilityDefinition[] shadowrazes = new AbilityDefinition[] { AbilityDefinitionManager.Instance.ShadowrazeNear, AbilityDefinitionManager.Instance.ShadowrazeMiddle, AbilityDefinitionManager.Instance.ShadowrazeFar };


        protected ShadowrazeAbility(string unlocalizedName, string displayName, AbilitySlot abilitySlot, int baseCastRange, bool affectsTotalAbilityLevelCount) :
            base(UNLOCALIZED_NAME_PREFIX + unlocalizedName, displayName, AbilityType.Active, AbilityTargetType.NoTarget, AbilityTargetFaction.Enemies, AbilityTargetUnitType.Living, DamageType.Magical, abilitySlot, 1, 4, baseCastRange: baseCastRange, affectsTotalAbilityLevelCount: affectsTotalAbilityLevelCount)
        {
        }

        public override bool CastAbility(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility, bool casterIsLocalPlayer, float calculatedDamage)
        {
            Texture2D texture = typeof(ShadowrazeProjectile).GetTexture();
            Vector2 spawnPosition = new Vector2(dotariaPlayer.player.position.X, dotariaPlayer.player.position.Y + dotariaPlayer.player.height + 25) - 
                                    new Vector2((-InternalGetCastRange(dotariaPlayer, playerAbility) * dotariaPlayer.player.direction) * DoTariaMath.TERRARIA_RANGE_RATIO, texture.Height / (ShadowrazeProjectile.FRAME_COUNT * 2f));

            for (int i = 0; i < 10; i++)
            {
                bool left = Main.rand.NextBool();

                Dust.NewDust(spawnPosition - new Vector2(37.5f, -60), 65, 15, dotariaPlayer.mod.DustType<ShadowTrail>(), 1f * (left ? -1 : 1), -1f, 0, new Color(255, 255, 255), 3f);
            }

            if (casterIsLocalPlayer)
                Projectile.NewProjectile(spawnPosition, Vector2.Zero, dotariaPlayer.mod.ProjectileType<ShadowrazeProjectile>(), (int)calculatedDamage, 0, dotariaPlayer.player.whoAmI);

            return true;
        }


        public float GetDamageIncreasePerStack(int abilityLevel) => 40 + abilityLevel * 10;


        // TODO Add support for talents.
        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 10;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 90 * Statistics.TERRARIA_MANA_RATIO;

        public override float GetAbilityDamage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 20 + 70 * playerAbility.Level;

        public override void OnAbilityLeveledUp(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility)
        {
            for (int i = 0; i < shadowrazes.Length; i++)
                if (shadowrazes[i] != this)
                    dotariaPlayer.AcquireOrLevelUp(shadowrazes[i], false);
        }
    }
}
