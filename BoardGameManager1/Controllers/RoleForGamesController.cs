//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using BoardGamesManager.Data;
//using DAL.Entities;
//using AutoMapper;
//using BoardGameManager1.DTO;
//using BoardGameManager1.Services;

//namespace BoardGameManager1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RoleForGamesController : ControllerBase
//    {
//        private readonly AppDbContext _context;
//        private readonly IMapper _mapper;
//        private readonly RoleForGameService _service;
//        public RoleForGamesController(AppDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//            _service = new RoleForGameService(context, mapper);
//        }

//        // GET: api/RoleForGames
//        [HttpGet]
//        public async Task<IEnumerable<RoleForGameDTOGet>> GetRolesForGames()
//        {
//            return await _service.GetRolesForGames();
//        }

//        // GET: api/RoleForGames/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<RoleForGameDTOGet>> GetRoleForGame(int id)
//        {
//            var roleForGame = await _service.GetRolesForGameById(id);

//            if (roleForGame == null)
//            {
//                return NotFound();
//            }

//            return roleForGame;
//        }

//        // PUT: api/RoleForGames/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutRoleForGame(int id, RoleForGameDTOEdit roleForGame)
//        {
            

//            _context.Entry(roleForGame).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!RoleForGameExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/RoleForGames
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<RoleForGame>> PostRoleForGame(RoleForGameDTOAdd roleForGame)
//        {
//            var id =await _service.AddRoleForGame(roleForGame);

//            return CreatedAtAction("GetRoleForGame", new { id = id }, roleForGame);
//        }

//        // DELETE: api/RoleForGames/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteRoleForGame(int id)
//        {
//            var roleForGame = await _context.RolesForGame.FindAsync(id);
//            if (roleForGame == null)
//            {
//                return NotFound();
//            }

//            await _service.DeleteGame(roleForGame);

//            return NoContent();
//        }

//        private bool RoleForGameExists(int id)
//        {
//            return _context.RolesForGame.Any(e => e.Id == id);
//        }
//    }
//}
