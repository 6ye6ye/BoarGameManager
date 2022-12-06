using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;
using BoardGamesManager.Data;
using BoardPlayerManager1.Services;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerService _service;

        public PlayersController(AppDbContext context, IMapper mapper)
        {
            _service = new PlayerService(context, mapper);
        }

        //Get players list for current user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDTOGet>>> GetPlayers()
        {
            try
            {
                return Ok(await _service.GetPlayersForCurrentUser(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("created")]
        public async Task<ActionResult<IEnumerable<PlayerDTOGetShort>>> GetCreatedPlayers()
        {
            try
            {
                return Ok(await _service.GetCreatedPlayersForCurrentUser(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDTOGet>> GetPlayer(string id)
        {
            try
            {
                return Ok(await _service.GetPlayerById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> PostPlayer(PlayerDTOAdd player)
        {
            try
            {
                player.CreatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                return await _service.AddPlayerToCurrentUser(player);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        [AppAutorize(UserRoleEnum.Admin)]
        public async Task<IActionResult> DeleteGameRole(Guid id)
        {
            try
            {
                await _service.DeletePlayer(id);
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

    }
}
