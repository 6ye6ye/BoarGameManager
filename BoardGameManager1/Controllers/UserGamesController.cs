using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGamesManager.Data;
using BoardUserGameManager1.Services;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserGamesController : ControllerBase
    {
        private readonly UserGameService _service;

        public UserGamesController(AppDbContext context, IMapper mapper)
        {
            _service = new UserGameService(context, mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDTOGet>>> GetCurrentUserGames()
        {
            try
            {
                return Ok(await _service.GetCurrentUserGames(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{gameId}")]
        public async Task<ActionResult<Guid>> PostCurrentUserGame(Guid gameId)
        {
            try
            {
                return await _service.AddCurrentUserGame(gameId, new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch (DoublicateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{gameId}")]
        public async Task<IActionResult> DeleteCurrentUserGame(Guid gameId)
        {
            try
            {
                await _service.DeleteCurrentUserGame(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)), gameId);
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
