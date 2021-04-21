using System;

namespace Games.Domain.ViewModel
{
    public class Leaderboard
    {
        public long PlayerId { get; set; }
        public long Balance { get; set; }
        public DateTimeOffset LastUpdateDate { get; set; }
    }
}