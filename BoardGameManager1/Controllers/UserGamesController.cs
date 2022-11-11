using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.DTO;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using BoardUserGameManager1.Services;
using BoardUserGamePlaceManager1.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGamesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserGameService _service;

        public UserGamesController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _service = new UserGameService(context, mapper);
        }

        // GET: api/UserGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGameDTOGet>>> GetUserGames()
        {
            try
            {
                return Ok(await _service.GetUsersGames());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Current")]
        public async Task<ActionResult<IEnumerable<GameDTOGet>>> GetCurrentUserGames()
        {
            try
            {
                return Ok(await _service.GetCurrentUserGames(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/UserGames/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserGameDTOGet>> GetUserGame(int id)
        //{
        //    var userGame = await _service.GetUserGameById(id);

        //    if (userGame == null)
        //    {
        //        return NotFound();
        //    }

        //    return userGame;
        //}

 
        // POST: api/UserGames
        [HttpPost]
        [Route("Current")]
        public async Task<ActionResult<int>> PostCurrentUserGame(int gameId)
        {
            try
            {
                return await _service.AddCurrentUserGame(gameId, User.FindFirstValue(ClaimTypes.NameIdentifier));
               // return CreatedAtAction("GetUserGame", new { id = newId }, userGame);
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

        // DELETE: api/UserGames/5
        [HttpDelete]
        [Route("Current")]
        public async Task<IActionResult> DeleteCurrentUserGame(int gameId)
        {
            try
            {
                await _service.DeleteCurrentUserGame( User.FindFirstValue(ClaimTypes.NameIdentifier), gameId);
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

        private bool UserGameExists(int id)
        {
            return _context.UserGames.Any(e => e.Id == id);
        }
    }
}
