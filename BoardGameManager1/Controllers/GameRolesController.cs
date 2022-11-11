using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.DTO;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameRolesController : ControllerBase
    {

        private readonly GameRolesService _service;

        public GameRolesController(AppDbContext context,IMapper mapper)
        {

            _service = new GameRolesService(context, mapper);
        }

        // GET: api/GameRoles
        [HttpGet]
        public async Task<IEnumerable<GameRoleDTOGet>> GetGameRoles()
        {
            return await _service.GetGameRoles();
        }

        // GET: api/GameRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameRoleDTOGet>> GetGameRole(int id)
        {
            try
            {
                var gameRole = await _service.GetGameRoleById(id);
                return gameRole;
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

        // POST: api/GameRoles
        [HttpPost]
        public async Task<ActionResult<GameRoleDTOAdd>> PostGameRole(GameRoleDTOAdd gameRole)
        {
            try
            {
                var id = _service.AddGameRole(gameRole);
                return CreatedAtAction("GetGameRole", new { id = id }, gameRole);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/GameRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameRole(int id)
        {
            try
            {
                await _service.DeleteGameRole(id);
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
    }
}
