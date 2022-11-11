using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoardGamesManager.Data;
using DAL.Entities;
using BoardUserGameManager1.Services;
using BoardGamePartyManager1.Services;
using BoardGameManager1.DTO;
using AutoMapper;
using BoardUserManager1.Services;
using System.Security.Claims;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Services;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamePartiesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly GamePartiesService _service;

        public GamePartiesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _service = new GamePartiesService(_context, _mapper);
        }

        // GET: api/GameParties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GamePartyDTOGet>>> GetGameParties()
        {
            try
            {
                return Ok(await _service.GetGameParties());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/GameParties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GamePartyDTOGet>> GetGameParty(int id)
        {
            try
            {
                var gameParty = await _service.GetGamePartyById(id);
                return gameParty;
      
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


        [HttpGet]
        [Route("Current/played")]
        public async Task<ActionResult<IEnumerable<GamePartyDTOGet>>> GetCurrentUserGamePartiesPlayer()
        {
            try
            {
                return Ok(await _service.GetCurrentUserGamePartiesPlayer(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route ("Current/created")]
        public async Task<ActionResult<IEnumerable<GamePartyDTOGet>>> GetCurrentUserCreatedGameParties()
        {
            try
            {
                return Ok(await _service.GetCurrentUserCreatedGameParties(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchGame(int id, [FromBody] GamePartyDTOEdit gamePartyDTO)
        {
            try
            {
                await _service.EditGameParty(id, gamePartyDTO);
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
        // POST: api/GameParties
        [HttpPost]
        [Route("Current")]
        public async Task<ActionResult<GamePartyDTOGet>> PostGameParty(GamePartyDTOAdd gameParty)
        {
            try
            {
                var newId = await _service.AddGameParty(gameParty, User.FindFirstValue(ClaimTypes.NameIdentifier));
                return CreatedAtAction("GetGameParty", new { id = newId }, gameParty);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/GameParties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameParty(int id)
        {
            try
            {
                await _service.DeleteGameParty(id);
                return NoContent();
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
