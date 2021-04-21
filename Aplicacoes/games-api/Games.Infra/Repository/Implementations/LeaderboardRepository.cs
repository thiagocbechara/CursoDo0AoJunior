using Games.Domain.ViewModel;
using Games.Infra.Db;
using Games.Infra.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Games.Infra.Repository.Implementations
{
    public class LeaderboardRepository : ILeaderboardRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaderboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Leaderboard> GetTop100(long gameId)
        {
            var list = _context.GameResults
                .Where(x => x.GameId == gameId)
                .OrderByDescending(x => x.Win)
                .Take(100)
                .Select(x => new Leaderboard
                {
                    PlayerId = x.PlayerId,
                    Balance = x.Win,
                    LastUpdateDate = x.Timestamp
                });
            return list.ToList();
        }
    }
}
