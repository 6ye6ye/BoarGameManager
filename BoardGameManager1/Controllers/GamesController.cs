using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using DAL.Common.Filters;
using DAL.Entities;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GamesController : ControllerBase
    {
        private readonly GameService _gameService;

        public GamesController(AppDbContext context, IMapper mapper)
        {
            _gameService = new GameService(context, mapper);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<GameDTOGet>>> GetGames()
        {

            return Ok(await _gameService.GetGames(User.FindFirstValue(ClaimTypes.NameIdentifier)));

        }

        [HttpGet]
        [Route("top")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<GameDTOGetShort>>> GetTopTenGames()
        {
            return Ok(await _gameService.GetTopTenGames(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Filtered")]
        public async Task<ActionResult<IEnumerable<GameDTOGet>>> GetGamesWithFilters([FromQuery] GameFilter filter)
        {
            return Ok(await _gameService.GetGamesWithFilters(filter, User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        [HttpGet]
        [Route("short")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<GameDTOGetShort>>> GetGamesShort()
        {
            return Ok(await _gameService.GetGamesShort());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GameDTOGet>> GetGame(string id)
        {

            var game = await _gameService.GetGameById(id);
            return Ok(game);
        }

        [HttpPut]
        [AppAutorize(UserRoleEnum.Admin)]
        public async Task<IActionResult> PutGame(GameDTOEdit gameDTO)
        {
            if (ModelState.IsValid)
            {
                await _gameService.EditGame(gameDTO);
                return Ok();
            }
            return BadRequest("Is not valid");
        }

        [HttpPost]
        [AppAutorize(UserRoleEnum.Admin)]
        public async Task<ActionResult<GameDTOGet>> PostGame(GameDTOAdd game)
        {
            if (ModelState.IsValid)
            {
                if (game.Image == null)
                    game.Image = "no-image-icon-6.png";
                return Ok(await _gameService.AddGame(game));
            }
            return ValidationProblem("Is not valid");
        }

        [HttpDelete("{id}")]
        [AppAutorize(UserRoleEnum.Admin)]
        public async Task<IActionResult> DeleteGame(string id)
        {
            try
            {
                await _gameService.DeleteGame(id);
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
        [Route("image")]
        [AppAutorize(UserRoleEnum.Admin)]
        public string UploadImage([FromForm] IFormFile file)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", uniqueFileName);
            file.CopyTo(new FileStream(imagePath, FileMode.Create));
            return uniqueFileName;
        }
    }
}
