using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using DTO;
using Microsoft.AspNetCore.Authorization;
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
        [AppAutorize(UserRoleEnum.Admin)]
        public async Task<IEnumerable<GameRoleDTOGet>> GetGameRoles()
        {
            return await _service.GetGameRoles();
        }

        [HttpGet]
        [Route("game")]
        [AllowAnonymous]
        public async Task<IEnumerable<GameRoleDTOGet>> GetGameRolesByGameId(int id)
        {
            return await _service.GetGameRolesByGameId(id);
        }

        // GET: api/GameRoles/5
        [HttpGet("{id}")]
        [AllowAnonymous]
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
        [AppAutorize(UserRoleEnum.Admin)]
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
        [AppAutorize(UserRoleEnum.Admin)]
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
