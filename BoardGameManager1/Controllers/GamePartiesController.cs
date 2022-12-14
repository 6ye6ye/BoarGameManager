using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGamePartyManager1.Services;
using BoardGamesManager.Data;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GamePartiesController : ControllerBase
    {
        private readonly GamePartiesService _service;

        public GamePartiesController(AppDbContext context, IMapper mapper)
        {
            _service = new GamePartiesService(context, mapper);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GamePartyDTOGet>> GetGameParty(Guid id)
        {
            var gameParty = await _service.GetGamePartyById(id);
            return gameParty;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GamePartyDTOGet>>> GetGameParties()
        {
            return Ok(await _service.GetGameParties(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }

        [HttpGet]
        [Route("played")]
        public async Task<ActionResult<IEnumerable<GamePartyDTOGet>>> GetCurrentUserGamePartiesPlayer()
        {
            return Ok(await _service.GetCurrentUserGamePartiesPlayer(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }

        [HttpGet]
        [Route("created")]
        public async Task<ActionResult<IEnumerable<GamePartyDTOGet>>> GetCurrentUserCreatedGameParties()
        {
            return Ok(await _service.GetCurrentUserCreatedGameParties(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }

        [HttpPut]
        public async Task<IActionResult> PatchGame( [FromBody] GamePartyDTOEdit gamePartyDTO)
        {
            await _service.EditGameParty(gamePartyDTO);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> PostGameParty(GamePartyDTOAdd gameParty)
        {
            return await _service.AddGameParty(gameParty, new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameParty(string id)
        {
            await _service.DeleteGameParty(id);
            return Ok();
        }
    }
}
