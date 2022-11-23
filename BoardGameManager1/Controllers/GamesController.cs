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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class GamesController : ControllerBase
    {
        //private readonly AppDbContext _context;
        //private readonly IMapper _mapper;
        private readonly GameService _gameService;

        public GamesController(AppDbContext context, IMapper mapper)
        {
            //_context = context;
            //_mapper = mapper;
            _gameService=new  GameService(context, mapper);
        }

        // GET: api/Games
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<GameDTOGet>>> GetGames()
        {
            try
            {
                return  Ok(await _gameService.GetGames(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("Filtered")]
        public async Task<ActionResult<IEnumerable<GameDTOGet>>> GetGamesWithFilters( [FromQuery] GameFilter filter)
        {
            try
            {
                return Ok(await _gameService.GetGamesWithFilters( filter, User.FindFirstValue(ClaimTypes.NameIdentifier)));
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

        // GET: api/Games/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GameDTOGet>> GetGame(int id)
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
        public async Task<IActionResult> PatchGame(int id, [FromBody] GameDTOEdit gameDTO)
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

        // POST: api/Games
        [HttpPost]
        [AppAutorize(UserRoleEnum.Admin)]
        public async Task<ActionResult<GameDTOGet>> PostGame( GameDTOAdd game)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (game.Image == null)
                        game.Image="no-image-icon-6.png";
                    var newId = await _gameService.AddGame(game);
                    return CreatedAtAction("GetGame", new { id = newId }, game);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("Is not valid");
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        [AppAutorize(UserRoleEnum.Admin)]
        public async Task<IActionResult> DeleteGame(int id)
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
        //[AppAutorize(UserRoleEnum.Admin)]
        public string UploadImage([FromForm] IFormFile file)
        {
            try
            {
                // getting file original name
                string FileName =  file.FileName;

                // combining GUID to create unique name before saving in wwwroot
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName;

                // getting full path inside wwwroot/images
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", uniqueFileName);

                // copying file
                file.CopyTo(new FileStream(imagePath, FileMode.Create));

                return uniqueFileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //[HttpPatch]
        //[Route("UserRate")]
        //public async Task<ActionResult<double>> GetCurrentUserGameRate([FromQuery] int gameId, int rate)
        //{
        //    try
        //    {
        //        return await _gameService.CurrentUserGameRate(gameId, User.FindFirstValue(ClaimTypes.NameIdentifier));
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

    }
}
