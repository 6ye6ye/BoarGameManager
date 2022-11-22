using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;
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

        // GET: api/GameRoles

        [HttpGet]
        [AppAutorize(UserRoleEnum.Admin)]
        public async Task<IEnumerable<GameRateDTOGet>> GetGamesRates()
        {
            return await _service.GetGamesRates();
        }

        [HttpGet("{gameId}")]
        [AllowAnonymous]
        public async Task<ActionResult<double>> GetGameRate(int gameId)
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
        // GET: api/GameRoles/5
        [HttpGet]
        [Route("user-gameRate/{gameId}")]
        [Authorize]
        public async Task<ActionResult<double>> GetCurrentUserGameRate(int gameId)
        {
            try
            {
                var gameRate = await _service.GetCurrentUserGameRate(gameId,User.FindFirstValue(ClaimTypes.NameIdentifier));
                return gameRate;
            }
 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost]
        //[Route("Rate")]
        //[Authorize]
        //public async Task<ActionResult<double>> PostCurrenUserRateGame(GameRateDTOPost gameRate)
        //{
        //    try
        //    {
        //        return await _service.AddCurrentUserGameRate(gameRate.GameId, gameRate.Rate, User.FindFirstValue(ClaimTypes.NameIdentifier));
        //    }
        //    catch (NotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
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
