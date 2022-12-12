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
            return Ok(await _service.GetPlayersForCurrentUser(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }
        [HttpGet]
        [Route("created")]
        public async Task<ActionResult<IEnumerable<PlayerDTOGetShort>>> GetCreatedPlayers()
        {
            return Ok(await _service.GetCreatedPlayersForCurrentUser(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDTOGet>> GetPlayer(string id)
        {
            return Ok(await _service.GetPlayerById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> PostPlayer(PlayerDTOAdd player)
        {
            player.CreatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _service.AddPlayerToCurrentUser(player);
        }

        [HttpDelete("{id}")]
        [AppAutorize(UserRoleEnum.Admin)]
        public async Task<IActionResult> DeleteGameRole(Guid id)
        {
            await _service.DeletePlayer(id);
            return Ok();
        }

    }
}
