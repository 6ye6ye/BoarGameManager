using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoardGamesManager.Data;
using DAL.Entities;
using AutoMapper;
using BoardPlayerManager1.Services;
using BoardGameManager1.Services;
using BoardGameManager1.DTO;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly PlayerService _service;

        public PlayersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _service = new PlayerService(context, mapper);
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDTOGet>>> GetPlayers()
        {
            try
            {
                return Ok(await _service.GetPlayers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDTOGet>> GetPlayer(int id)
        {
            try
            {
                return Ok(await _service.GetPlayers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }

    }
}
