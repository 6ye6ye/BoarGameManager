using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;
using BoardGameManager1.Helpers.Parsers;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using DAL.Common.Filters;
using DAL.Entities;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static DTO.GameGetFromApiParams;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AppAutorize(UserRoleEnum.Admin)]
    public class GameParserController : ControllerBase
    {
        private readonly GameService _gameService;
        private readonly IGameParser _gameParcer;

        public GameParserController(AppDbContext context, IMapper mapper, IGameParser gameParcer)
        {
            _gameService = new GameService(context, mapper);
            _gameParcer = gameParcer;
        }
      
        [HttpGet]
        [Route("top-by-rate")]
        public async Task<ActionResult<IEnumerable<GameDTOGet>>> DownloadGamesByRateFromApi([FromQuery] ParamsWithCount param)
        {
            var games = await _gameParcer.GetTopGamesByRate(param.Count);
            var gamesDto = await _gameService.AddGames(games);
            return Ok(gamesDto);
        }

        [HttpGet]
        [Route("last-added")]
        public async Task<ActionResult<IEnumerable<GameDTOGet>>> DownloadGamesLastAddedFromApi([FromQuery] ParamsWithCount param)
        {
            var games = await _gameParcer.GetLastAddedGames(param.Count);
            var gamesDto = await _gameService.AddGames(games);
            return Ok(gamesDto);
        }

        [HttpGet]
        [Route("by-user")]
        public async Task<ActionResult<IEnumerable<GameDTOGet>>> DownloadGamesFromApiUser([FromQuery]  ParamsWithCountAndUser param)
        {
            var games = await _gameParcer.GetGamesByUserCollection(param.UserName, param.Count);
            var gamesDto = await _gameService.AddGames(games);
            return Ok(gamesDto);
        }

    }
}
