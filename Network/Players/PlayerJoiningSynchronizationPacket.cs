using System.Collections.Generic;
using System.IO;
using System.Linq;
using DoTaria.Abilities;
using DoTaria.Helpers;
using DoTaria.Heroes;
using DoTaria.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Networking.Packets;

namespace DoTaria.Network.Players
{
    public sealed class PlayerJoiningSynchronizationPacket : ModPlayerNetworkPacket<DoTariaPlayer>
    {
        private const string HERO_UNDEFINED = "undefined";


        public PlayerJoiningSynchronizationPacket()
        {
        }

        public PlayerJoiningSynchronizationPacket(DoTariaPlayer dotariaPlayer)
        {
            HeroSelected = dotariaPlayer.HeroSelected;
            Hero = HeroSelected ? dotariaPlayer.Hero.UnlocalizedName : HERO_UNDEFINED;

            Level = dotariaPlayer.Level;
            SerializedAbilities = AbilitiesHelper.SerializeAbilities(dotariaPlayer.AcquiredAbilities.Values.ToArray());
        }


        protected override bool PostReceive(BinaryReader reader, int fromWho)
        {
            if (!IsResponse && Main.netMode == NetmodeID.MultiplayerClient)
            {
                IsResponse = true;
                Send(Main.myPlayer, Player.whoAmI);
            }

            if (!HeroSelected) 
                return true;

            ModPlayer.Hero = HeroDefinitionManager.Instance[Hero];
            ModPlayer.Level = Level;

            if (!string.IsNullOrWhiteSpace(SerializedAbilities))
            {
                Dictionary<AbilityDefinition, PlayerAbility> acquiredAbilities = new Dictionary<AbilityDefinition, PlayerAbility>();
                PlayerAbility[] playerAbilities = AbilitiesHelper.DeserializeAbilities(SerializedAbilities);

                ModPlayer.AcquiredAbilities = acquiredAbilities;

                for (int i = 0; i < playerAbilities.Length; i++)
                    acquiredAbilities.Add(playerAbilities[i].Ability, playerAbilities[i]);
            }

            return true;
        }


        public bool HeroSelected { get; set; }

        public string Hero { get; set; }

        public int Level { get; set; }

        public bool IsResponse { get; set; }

        public string SerializedAbilities { get; set; }
    }
}