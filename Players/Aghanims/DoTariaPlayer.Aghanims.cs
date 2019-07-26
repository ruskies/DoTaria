using DoTaria.Buffs;
using DoTaria.Extensions;
using DoTaria.Items.Aghanims;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private void SaveAghanims(TagCompound tag)
        {
            tag.Add(nameof(AghanimsBlessingConsumed), AghanimsBlessingConsumed);
        }

        private void LoadAghanims(TagCompound tag)
        {
            AghanimsBlessingConsumed = tag.GetBool(nameof(AghanimsBlessingConsumed));
        }


        private void PreUpdateMovementAghanims()
        {
            if (HasAghanims() && !player.HasBuff<AghanimUpgrade>())
                player.AddBuff<AghanimUpgrade>(int.MaxValue);
            else if (!HasAghanims() && player.HasBuff<AghanimUpgrade>())
                player.ClearBuff<AghanimUpgrade>();
                
        }


        /// <summary></summary>
        /// <returns>true if the player has anything giving him aghanim's scepter upgrades; otherwise false.</returns>
        public bool HasAghanims() => AghanimsBlessingConsumed || player.GetItemsByType<IGiveAghanimUpgrade>(armor: true, accessories: true).Count > 0;


        /// <summary>true if the player has consumed the item <see cref="AghanimsBlessing"/>; otherwise false. Use <see cref="HasAghanims"/> for anything related to Aghanim-related abilities.</summary>
        public bool AghanimsBlessingConsumed { get; internal set; }
    }
}
