using DoTaria.Leveling.Rules.Invasions;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private void PreUpdateInvasions()
        {
            if (Main.invasionType != InvasionID.None && WaitingForEndOfInvasionType != InvasionID.None)
                WaitingForEndOfInvasionType = Main.invasionType;

            if (Main.invasionProgress == Main.invasionProgressMax && WaitingForEndOfInvasionType != InvasionID.None)
            {
                OnPlayerSurvivedInvasion(WaitingForEndOfInvasionType);
                WaitingForEndOfInvasionType = InvasionID.None;
            }
        }


        public int WaitingForEndOfInvasionType { get; private set; }
    }
}
