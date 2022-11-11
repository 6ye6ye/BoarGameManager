using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.DTO;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGameManager1.Controllers
{
    public class GameRateController: ControllerBase
    {

        private readonly GameRateService _service;

        public GameRateController(AppDbContext context, IMapper mapper)
        {
            _service = new GameRateService(context, mapper);
        }

        // GET: api/GameRoles
        [HttpGet]
        public async Task<IEnumerable<GameRateDTOGet>> GetGamesRates()
        {
            return await _service.GetGamesRates();
        }

        // GET: api/GameRoles/5
        [HttpGet]
        [Route("Current")]
        public async Task<ActionResult<double>> GetGameRate(int gameId)
        {
            try
            {
                var gameRole = await _service.GetCurrentUserGameRate(gameId,User.FindFirstValue(ClaimTypes.NameIdentifier));
                return gameRole;
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
        [Route("Rate")]
        public async Task<ActionResult<double>> PostRateGame([FromQuery] int gameId, int rate)
        {
            try
            {
                return await _service.AddCurrentUserGameRate(gameId, rate, User.FindFirstValue(ClaimTypes.NameIdentifier));
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
        [HttpPatch]
        [Route("Rate")]
        public async Task<ActionResult<double>> ChangeGameRate([FromQuery] int gameId, int rate)
        {
            try
            {
                return await _service.EditCurrentUserGameRate(gameId, rate, User.FindFirstValue(ClaimTypes.NameIdentifier));
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
