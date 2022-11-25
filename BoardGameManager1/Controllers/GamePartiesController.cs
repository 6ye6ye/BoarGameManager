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
            try
            {
                var gameParty = await _service.GetGamePartyById(id);
                return gameParty;
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GamePartyDTOGet>>> GetGameParties()
        {
            try
            {
                return Ok(await _service.GetGameParties(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("played")]
        public async Task<ActionResult<IEnumerable<GamePartyDTOGet>>> GetCurrentUserGamePartiesPlayer()
        {
            try
            {
                return Ok(await _service.GetCurrentUserGamePartiesPlayer(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("created")]
        public async Task<ActionResult<IEnumerable<GamePartyDTOGet>>> GetCurrentUserCreatedGameParties()
        {
            try
            {
                return Ok(await _service.GetCurrentUserCreatedGameParties(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchGame(string id, [FromBody] GamePartyDTOEdit gamePartyDTO)
        {
            try
            {
                await _service.EditGameParty(id, gamePartyDTO);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> PostGameParty(GamePartyDTOAdd gameParty)
        {
            try
            {
                return await _service.AddGameParty(gameParty, new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameParty(string id)
        {
            try
            {
                await _service.DeleteGameParty(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
