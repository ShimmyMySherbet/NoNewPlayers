using System;
using NoNewPlayers.Models;
using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using ShimmyMySherbet.Moderation2.API.Models;
using ShimmyMySherbet.MySQL.EF.Core;

namespace NoNewPlayers
{
    public class NNPPlugin : RocketPlugin<NoNewPlayersConfig>
    {
        private NoNewPlayersRestrictor Instance;
        private MySQLEntityClient Client;
        public static NNPPlugin PlInstance;
        public DateTime BanFrom;
        public override void LoadPlugin()
        {
            PlInstance = this;
            base.LoadPlugin();

            BanFrom = new DateTime(Configuration.Instance.BanFromTicks);
            Client = new MySQLEntityClient(Configuration.Instance.Database);

            Logger.Log("Connecting to database...");

            if (Client.Connect(out var msg))
            {
                Logger.Log("Conencted to database!");

                Logger.Log("Initializing rules...");

                Instance = new NoNewPlayersRestrictor(Client, this);

                AccessRestrictions.RegisterSingleton(Instance);
            }
            else
            {
                Logger.LogError($"Failed to connect to database: {msg}");
                UnloadPlugin(PluginState.Failure);
            }
        }

        public override void UnloadPlugin(PluginState state = PluginState.Unloaded)
        {
            base.UnloadPlugin(state);
            try
            {
                AccessRestrictions.DeregisterSingleton(Instance);
                Client.Disconnect();
            }
            catch (System.Exception)
            {
            }
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "PlayerBlocked", "Sorry {0}, we're not accepting new players right now"}
        };
    }
}