using Games.Domain.Models;
using Games.Infra.Db;
using Games.Infra.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Infra.Repository.Implementations
{
    public class GameResultRepository : IGameResultRepository
    {
        private readonly ApplicationDbContext _context;

        public GameResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveOrUpdate(GameResult gameResult)
        {
            var gameResultDb = _context.GameResults.Where(x => x.PlayerId == gameResult.PlayerId && x.GameId == gameResult.PlayerId).FirstOrDefault();
            if (gameResultDb != null)
            {
                gameResultDb.Win += gameResult.Win;
                gameResultDb.Timestamp = gameResult.Timestamp;
                _context.GameResults.Update(gameResultDb);
            }
            else
            {
                await _context.GameResults.AddAsync(gameResult);
            }
            await _context.SaveChangesAsync();
        }
    }
}
