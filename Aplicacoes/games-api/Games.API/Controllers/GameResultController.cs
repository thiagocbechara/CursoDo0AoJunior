using Games.Domain.Models;
using Games.Infra.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Games.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameResultController : ControllerBase
    {
        private readonly IGameResultRepository _resultRepository;

        public GameResultController(IGameResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Post(GameResult gameResult)
        {
            await _resultRepository.SaveOrUpdate(gameResult);
            return Ok();
        }
    }
}