using System;
using System.Threading;
using System.Threading.Tasks;
using NoNewPlayers.Models;
using Rocket.Core.Logging;
using ShimmyMySherbet.Moderation2.API.Interfaces;
using ShimmyMySherbet.Moderation2.API.Models;
using ShimmyMySherbet.MySQL.EF.Core;

namespace NoNewPlayers
{
    public class NoNewPlayersRestrictor : IAccessRestrictor
    {
        private MySQLEntityClient Client;
        private NNPPlugin Plugin;
        private bool Enabled => Plugin.Configuration.Instance.Enabled;

        public NoNewPlayersRestrictor(MySQLEntityClient client, NNPPlugin plugin)
        {
            Client = client;
            Plugin = plugin;
        }

        public async Task<AccessGrant> Verify(QueuePlayer queuePlayer, CancellationToken cancellationToken)
        {
            if (!Enabled)
            {
                return AccessGrant.Accept();
            }

            if (Client.TableExists("Moderation_PlayerInfo"))
            {
                var record = await Client.QuerySingleAsync<PlayerInfo>("SELECT * FROM Moderation_PlayerInfo WHERE PlayerID=@0;", queuePlayer.CSteamID.m_SteamID);

                if (record == null || record.FirstSeen > Plugin.BanFrom)
                {
                    return AccessGrant.Deny(Plugin.Translate("PlayerBlocked", queuePlayer.DisplayName));
                }

                return AccessGrant.Accept();
            }
            else
            {
                Logger.LogWarning("Failed to find Moderation2 player info table.");
                return AccessGrant.Accept();
            }
        }
    }
}