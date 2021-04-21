using Games.Domain.ViewModel;
using Games.Infra.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace Games.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        private readonly ILeaderboardRepository _repository;

        public LeaderboardController(ILeaderboardRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IList<Leaderboard> Top100(long gameId, [FromServices] IMemoryCache cache)
        {
            var result = cache.GetOrCreate(gameId, context =>
            {
                context.SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
                return _repository.GetTop100(gameId);
            });
            return result;
        }
    }
}
