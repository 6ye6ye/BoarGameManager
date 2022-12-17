using AutoMapper;
using BoardGameManager1.Parser.GameParser;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using BoardPlayerManager1.Services;
using DAL.Entities;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGameManager1.Controllers
{
    public class ParserController : Controller
    {
        private readonly IGameParser _gameParcer;

        public ParserController(AppDbContext context, IMapper mapper, IGameParser gameParcer)
        {
            _gameParcer = gameParcer;
        }

        //[HttpGet]
        //[AllowAnonymous]
        //[Route("games")]
        //public async Task<ActionResult<IEnumerable<Game>>> DownloadGamesFromApi(int count)
        //{
        //    return Ok(await _gameParcer.DownloadGamesFromApi(count));
        //}
    }
}
