using DoTaria.Dusts;
using DoTaria.Extensions;
using System.Collections.Generic;
using DoTaria.Network;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        public static DoTariaPlayer Get(Player player) => player.GetModPlayer<DoTariaPlayer>();


        public override void Initialize()
        {
            InitializeAbilities();
            InitializeHeroes();
        }


        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            KillHeroes(damage, hitDirection, pvp, damageSource);
        }


        public override void OnEnterWorld(Player player)
        {
            OnEnterWorldHeroes(player);
            OnEnterWorldAbilities(player);

            OnEnterWorldNetworking(player);
        }

        public void OnKilledNPC(NPC npc)
        {
            OnKilledNPCHeroes(npc);
            OnKilledNPCLevels(npc);
        }


        public override void ModifyWeaponDamage(Item item, ref float add, ref float mult, ref float flat)
        {
            ModifyWeaponDamageHeroes(item, ref add, ref mult, ref flat);
        }


        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            PostHurtHeroes(pvp, quiet, damage, hitDirection, crit);
            
            base.PostHurt(pvp, quiet, damage, hitDirection, crit);
        }

        public override void PostUpdate()
        {
            if (!player.dead)
            {
                List<ISpawnDustOnPlayerPostUpdate> sdoppu = player.GetItemsByType<ISpawnDustOnPlayerPostUpdate>(armor: true, armorSocial: true, accessories: true, accessoriesSocial: true);

                for (int i = 0; i < sdoppu.Count; i++)
                    sdoppu[i].SpawnDustOnPlayerPostUpdate(this);
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (!PreHurtHeroes(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource))
                return false;

            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }

        public override void PreUpdate()
        {
            PreUpdateAttributes();
            PreUpdateAbilities();

            if (Main.invasionType != InvasionID.None && Main.invasionProgress >= Main.invasionProgressMax - 1)
                Main.NewText("Invasion Completed!");

            PreUpdateLevels();
        }

        public override void PreUpdateMovement()
        {
            PreUpdateMovementAttributes();
            PreUpdateMovementAghanims();

            PreUpdateMovementHeroes();

            PreUpdateMovementAbilities();
        }


        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            ProcessTriggersHotkeys(triggersSet);
        }


        public override void ResetEffects()
        {
            ResetEffectsAttributes();
            ResetEffectsStatistics();

            ResetEffectsHeroes();

            ResetEffectsAbilities();
        }


        public bool BeingInvaded { get; private set; }
    }
}
