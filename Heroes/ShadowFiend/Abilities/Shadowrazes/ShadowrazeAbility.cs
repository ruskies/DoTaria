using DoTaria.Abilities;
using DoTaria.Commons;
using DoTaria.Enums;
using DoTaria.Extensions;
using DoTaria.Heroes.ShadowFiend.Skins.Default;
using DoTaria.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace DoTaria.Heroes.ShadowFiend.Abilities.Shadowrazes
{
    public abstract class ShadowrazeAbility : AbilityDefinition
    {
        public const string UNLOCALIZED_NAME_PREFIX = ShadowFiendHero.UNLOCALIZED_NAME + ".";

        public static readonly AbilityDefinition[] shadowrazes = new AbilityDefinition[] { AbilityDefinitionManager.Instance.ShadowrazeNear, AbilityDefinitionManager.Instance.ShadowrazeMiddle, AbilityDefinitionManager.Instance.ShadowrazeFar };


        protected ShadowrazeAbility(string unlocalizedName, string displayName, AbilitySlot abilitySlot, int range) :
            base(UNLOCALIZED_NAME_PREFIX + unlocalizedName, displayName, AbilityType.Active, DamageType.Magical, abilitySlot, 1, 4)
        {
            Range = range;
        }

        public override bool CastAbility(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility)
        {
            Texture2D texture = typeof(ShadowrazeProjectile).GetTexture();
            Vector2 spawnPosition = new Vector2(dotariaPlayer.player.position.X, dotariaPlayer.player.position.Y + dotariaPlayer.player.height + 25) - 
                                    new Vector2((-Range * dotariaPlayer.player.direction) * DoTariaMath.TERRARIA_RANGE_RATIO, texture.Height / (ShadowrazeProjectile.FRAME_COUNT * 2f));

            for (int i = 0; i < 10; i++)
            {
                bool left = Main.rand.NextBool();

                Dust.NewDust(spawnPosition - new Vector2(37.5f, -60), 65, 15, dotariaPlayer.mod.DustType<ShadowTrail>(), 1f * (left ? -1 : 1), -1f, 0, new Color(255, 255, 255), 3f);
            }

            Projectile.NewProjectile(spawnPosition, Vector2.Zero, dotariaPlayer.mod.ProjectileType<ShadowrazeProjectile>(), (int)InternalGetAbilityDamage(dotariaPlayer, playerAbility), 0, dotariaPlayer.player.whoAmI);

            return true;
        }


        // TODO Add support for talents.
        public override float GetCooldown(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 10;

        public override float GetManaCost(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 90;

        public override float GetAbilityDamage(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility) => 20 + 70 * playerAbility.Level;

        public override void OnAbilityLeveledUp(DoTariaPlayer dotariaPlayer, PlayerAbility playerAbility)
        {
            for (int i = 0; i < shadowrazes.Length; i++)
                if (shadowrazes[i] != this)
                    dotariaPlayer.AcquireOrLevelUp(shadowrazes[i]);
        }


        public int Range { get; }
    }
}
