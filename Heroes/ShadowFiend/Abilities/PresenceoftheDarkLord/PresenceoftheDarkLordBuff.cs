using System.Collections.Generic;
using System.Linq;
using DoTaria.Abilities;
using DoTaria.Buffs;
using DoTaria.Helpers;
using DoTaria.Players;
using Microsoft.Xna.Framework;
using Terraria;

namespace DoTaria.Heroes.ShadowFiend.Abilities.PresenceoftheDarkLord
{
    public sealed class PresenceoftheDarkLordBuff : DoTariaBuff
    {
        public PresenceoftheDarkLordBuff() : base("Presence of the Dark Lord", "", true, false, false, false)
        {
        }


        public override void Update(NPC npc, ref int buffIndex)
        {
            PresenceoftheDarkLordAbility ability = AbilityDefinitionManager.Instance.PresenceoftheDarkLord;

            IEnumerable<DoTariaPlayer> players = Main.player.Where(p =>
            {
                if (p.name == "")
                    return false;

                DoTariaPlayer player = DoTariaPlayer.Get(p);
                bool hasPotDL = player.HasAbility(ability);

                if (hasPotDL)
                    return Vector2.Distance(p.Center, npc.Center) <=
                           ability.InternalGetCastRange(player);

                return false;
            }).Select(p => DoTariaPlayer.Get(p));

            PlayerAbility highestPlayerAbility = null;
            DoTariaPlayer highestLevelDoTariaPlayer = null;

            foreach (DoTariaPlayer dotariaPlayer in players)
                if (highestPlayerAbility == null || dotariaPlayer.AcquiredAbilities[ability].Level > highestPlayerAbility.Level)
                {
                    highestPlayerAbility = dotariaPlayer.AcquiredAbilities[ability];
                    highestLevelDoTariaPlayer = dotariaPlayer;
                }

            if (highestPlayerAbility == null)
                return;

            
            npc.defense = npc.defDefense - (int)(npc.defDefense * ability.GetDefenseReduction(highestLevelDoTariaPlayer, highestPlayerAbility));
        }

        public override void ModifyBuffTip(ref string tip, ref int rare)
        {
            tip += $"Losing a portion of your defense";
        }
    }
}