using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Unturned.Chat;

namespace NoNewPlayers.Commands
{
    public class SetBanAfterCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;
        public string Name => "NNPResetBanFrom";
        public string Help => "Sets the ban-from time to the current time";
        public string Syntax => Name;
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string>() { "NNP.ResetBanFrom" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var pl = NNPPlugin.PlInstance;

            pl.BanFrom = DateTime.Now;
            pl.Configuration.Instance.BanFromTicks = pl.BanFrom.Ticks;
            pl.Configuration.Save();
            UnturnedChat.Say(caller, "Set the 'Ban From' time to the current time.");
            UnturnedChat.Say(caller, "Players who tried to join the server before now will be allowed to join.");
        }
    }
}
