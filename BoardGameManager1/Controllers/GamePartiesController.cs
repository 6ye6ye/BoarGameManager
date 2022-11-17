using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;
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
        //private readonly AppDbContext _context;
        //private readonly IMapper _mapper;
        private readonly GamePartiesService _service;

        public GamePartiesController(AppDbContext context, IMapper mapper)
        {
            //_context = context;
            //_mapper = mapper;
            _service = new GamePartiesService(context, mapper);
        }

        // GET: api/GameParties

      
        // GET: api/GameParties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GamePartyDTOGet>> GetGameParty(int id)
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
                return Ok(await _service.GetGameParties(User.FindFirstValue(ClaimTypes.NameIdentifier)));
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
                return Ok(await _service.GetCurrentUserGamePartiesPlayer(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    
        [HttpGet]
        [Route ("created")]
        public async Task<ActionResult<IEnumerable<GamePartyDTOGet>>> GetCurrentUserCreatedGameParties()
        {
            try
            {
                return Ok(await _service.GetCurrentUserCreatedGameParties(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchGame(int id, [FromBody] GamePartyDTOEdit gamePartyDTO)
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

        // POST: api/GameParties
        [HttpPost]

      
        public async Task<ActionResult<int>> PostGameParty(GamePartyDTOAdd gameParty)
        {
            try
            {
                return  await _service.AddGameParty(gameParty, User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/GameParties/5
        [HttpDelete("{id}")]
 
        public async Task<IActionResult> DeleteGameParty(int id)
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
