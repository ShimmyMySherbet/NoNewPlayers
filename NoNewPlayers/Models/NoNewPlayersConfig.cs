using System;
using Rocket.API;
using ShimmyMySherbet.MySQL.EF.Models;

namespace NoNewPlayers.Models
{
    public class NoNewPlayersConfig : IRocketPluginConfiguration
    {
        public DatabaseSettings Database;

        public bool Enabled = true;

        public long BanFromTicks;

        public void LoadDefaults()
        {
            BanFromTicks = DateTime.Now.Ticks;
            Database = DatabaseSettings.Default;
        }
    }
}