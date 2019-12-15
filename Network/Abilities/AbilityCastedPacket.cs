using System.IO;
using DoTaria.Abilities;
using DoTaria.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Networking.Packets;

namespace DoTaria.Network.Abilities
{
    public sealed class AbilityCastedPacket : ModPlayerNetworkPacket<DoTariaPlayer>
    {
        public AbilityCastedPacket()
        {
        }

        public AbilityCastedPacket(AbilityDefinition ability, int newCooldown)
        {
            AbilityName = ability.UnlocalizedName;
            NewCooldown = newCooldown;
        }


        protected override bool PostReceive(BinaryReader reader, int fromWho)
        {
            PlayerAbility playerAbility = ModPlayer.AcquiredAbilities[AbilityDefinitionManager.Instance[AbilityName]];

            playerAbility.Ability.InternalCastAbility(ModPlayer, playerAbility, false);
            playerAbility.Cooldown = NewCooldown;

            return true;
        }


        public string AbilityName { get; set; }

        public int NewCooldown { get; set; }
    }
}
