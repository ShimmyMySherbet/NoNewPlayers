using System.Collections.Generic;
using Rocket.API;
using Rocket.Unturned.Chat;

namespace NoNewPlayers.Commands
{
    public class ToggleAllowPlayers : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Console;
        public string Name => "NNPToggle";
        public string Help => "Toggles NoNewPlayers";
        public string Syntax => Name;
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string>() { "NNP.Toggle" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            NNPPlugin.PlInstance.Configuration.Instance.Enabled = !NNPPlugin.PlInstance.Configuration.Instance.Enabled;
            if (NNPPlugin.PlInstance.Configuration.Instance.Enabled)
            {
                UnturnedChat.Say(caller, "Enabled NoNewPlayers");
            }
            else
            {
                UnturnedChat.Say(caller, "Disabled NoNewPlayers");
            }
        }
    }
}