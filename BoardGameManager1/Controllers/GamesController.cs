using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using DAL.Common.Filters;
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
            try
            {
                return Ok(await _gameService.GetGames(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("Filtered")]
        public async Task<ActionResult<IEnumerable<GameDTOGet>>> GetGamesWithFilters([FromQuery] GameFilter filter)
        {
            try
            {
                return Ok(await _gameService.GetGamesWithFilters(filter, User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("short")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<GameDTOGetShort>>> GetGamesShort()
        {
            try
            {
                return Ok(await _gameService.GetGamesShort());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GameDTOGet>> GetGame(string id)
        {
            try
            {
                var game = await _gameService.GetGameById(id);
                return Ok(game);
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

        [HttpPatch("{id}")]
        [AppAutorize(UserRoleEnum.Admin)]
        public async Task<IActionResult> PatchGame(string id, [FromBody] GameDTOEdit gameDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _gameService.EditGame(id, gameDTO);
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
            return BadRequest("Is not valid");
        }

        [HttpPost]
        [AppAutorize(UserRoleEnum.Admin)]
        public async Task<ActionResult<GameDTOGet>> PostGame(GameDTOAdd game)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (game.Image == null)
                        game.Image = "no-image-icon-6.png";
                    return Ok( await _gameService.AddGame(game));
                    
                }
                catch (DoublicateException ex)
                {
                    return Conflict(ex.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("Is not valid");
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
            try
            {
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", uniqueFileName);
                file.CopyTo(new FileStream(imagePath, FileMode.Create));
                return uniqueFileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
