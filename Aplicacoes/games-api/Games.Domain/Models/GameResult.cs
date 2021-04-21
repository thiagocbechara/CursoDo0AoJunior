using System;

namespace Games.Domain.Models
{
    public class GameResult : BaseEntity
    {
        public long PlayerId { get; set; }
        public long GameId { get; set; }
        public long Win { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
