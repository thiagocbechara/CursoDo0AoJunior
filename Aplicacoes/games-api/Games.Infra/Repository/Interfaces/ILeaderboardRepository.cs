using Games.Domain.ViewModel;
using System.Collections.Generic;

namespace Games.Infra.Repository.Interfaces
{
    public interface ILeaderboardRepository
    {
        IList<Leaderboard> GetTop100(long gameId);
    }
}
