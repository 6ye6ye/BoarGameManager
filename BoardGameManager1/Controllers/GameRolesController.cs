using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GameRolesController : ControllerBase
    {
        private readonly GameRolesService _service;

        public GameRolesController(AppDbContext context, IMapper mapper)
        {

            _service = new GameRolesService(context, mapper);
        }

        [HttpGet]
        [AppAutorize(UserRoleEnum.Admin)]
        public async Task<IEnumerable<GameRoleDTOGet>> GetGameRoles()
        {
            return await _service.GetGameRoles();
        }

        [HttpGet]
        [Route("game")]
        [AllowAnonymous]
        public async Task<IEnumerable<GameRoleDTOGet>> GetGameRolesByGameId(Guid id)
        {
            return await _service.GetGameRolesByGameId(id);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GameRoleDTOGet>> GetGameRole(string id)
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

        [HttpPost]
        [AppAutorize(UserRoleEnum.Admin)]
        public async Task<ActionResult<GameRoleDTOAdd>> PostGameRole(GameRoleDTOAdd gameRole)
        {
            try
            {
                var id = await _service.AddGameRole(gameRole);
                return CreatedAtAction("GetGameRole", new { id = id }, gameRole);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        [AppAutorize(UserRoleEnum.Admin)]
        public async Task<IActionResult> DeleteGameRole(Guid id)
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
