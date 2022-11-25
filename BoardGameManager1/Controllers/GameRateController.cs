using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    public class GameRateController : ControllerBase
    {
        private readonly GameRateService _service;

        public GameRateController(AppDbContext context, IMapper mapper)
        {
            _service = new GameRateService(context, mapper);
        }

        [HttpGet("{gameId}")]
        [AllowAnonymous]
        public async Task<ActionResult<double>> GetGameRate(Guid gameId)
        {
            try
            {
                var gameRate = await _service.GetGameRate(gameId);
                return gameRate;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("user-gameRate/{gameId}")]
        [Authorize]
        public async Task<ActionResult<double>> GetCurrentUserGameRate(Guid gameId)
        {
            try
            {
                var gameRate = await _service.GetCurrentUserGameRate(gameId, new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                return gameRate;
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<double>> ChangeCurrentUserGameRate([FromBody] GameRateDTOPost gameRate)
        {
            try
            {
                return await _service.EditCurrentUserGameRate(gameRate.GameId, gameRate.Rate, User.FindFirstValue(ClaimTypes.NameIdentifier));
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
