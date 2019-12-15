using System.IO;
using DoTaria.Abilities;
using DoTaria.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Networking.Packets;

namespace DoTaria.Network.Players
{
    public sealed class PlayerAbilityLeveledUpPacket : ModPlayerNetworkPacket<DoTariaPlayer>
    {
        public PlayerAbilityLeveledUpPacket()
        {
        }

        public PlayerAbilityLeveledUpPacket(AbilityDefinition ability)
        {
            AbilityName = ability.UnlocalizedName;
        }


        protected override bool PostReceive(BinaryReader reader, int fromWho)
        {
            ModPlayer.AcquireOrLevelUp(AbilityDefinitionManager.Instance[AbilityName], networkCall: true);

            return true;
        }


        public string AbilityName { get; set; }
    }
}