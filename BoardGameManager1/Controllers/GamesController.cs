﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoardGamesManager.Data;
using DAL.Entities;
using BoardGameManager1.Services;
using BoardGameManager1.DTO;
using AutoMapper;
using BoardGamePartyManager1.Services;
using System.Security.Claims;
using BoardGameManager1.Entities;
using BoardGameManager1.Common.Exceptions;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly GameService _gameService;

        public GamesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _gameService=new  GameService(_context, _mapper);
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDTOGet>>> GetGames()
        {
            try
            {
                return Ok(await _gameService.GetGames());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
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
        public async Task<IActionResult> PatchGame(int id, [FromBody] GameDTOEdit gameDTO)
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

        // POST: api/Games
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(GameDTOAdd game)
        {
            try
            {
                var newId = _gameService.AddGame(game);
                return CreatedAtAction("GetGame", new { id = newId }, game);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }       
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
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
        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
