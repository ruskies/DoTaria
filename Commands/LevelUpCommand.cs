using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoTaria.Players;
using Terraria.ModLoader;

namespace DoTaria.Commands
{
    public sealed class LevelUpCommand : ModCommand
    {
        public override void Action(CommandCaller caller, string input, string[] args)
        {
            DoTariaPlayer.Get(caller.Player).Level += int.Parse(args[0]);
        }

        public override string Command => "lvlup";
        public override CommandType Type => CommandType.Chat;
    }
}
