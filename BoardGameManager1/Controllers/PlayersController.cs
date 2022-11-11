using AutoMapper;
using BoardGameManager1.Enums;
using BoardGamesManager.Data;
using BoardPlayerManager1.Services;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AppAutorize(UserRoleEnum.Admin)]
    public class PlayersController : ControllerBase
    {
        //private readonly AppDbContext _context;
        //private readonly IMapper _mapper;
        private readonly PlayerService _service;

        public PlayersController(AppDbContext context, IMapper mapper)
        {
            //_context = context;
            //_mapper = mapper;
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
