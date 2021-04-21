using Games.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Games.Infra.Repository.Interfaces
{
    public interface IGameResultRepository
    {
        Task SaveOrUpdate(GameResult gameResult);
    }
}
