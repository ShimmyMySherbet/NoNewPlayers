using System;

namespace NoNewPlayers.Models
{
    public class PlayerInfo
    {
        public ulong PlayerID;

        public string IP;

        public string HWID;

        public string CharacterName;

        public DateTime FirstSeen;

        public DateTime LastJoin;

        public int PlayTime;
    }
}