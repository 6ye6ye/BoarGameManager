using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GamePartyMembersController : ControllerBase
    {
        private readonly GamePartyMemberService _service;

        public GamePartyMembersController(AppDbContext context, IMapper mapper)
        {
            _service = new GamePartyMemberService(context, mapper);
        }

        [HttpGet]
        [Route("gameParty/{id}")]
        public async Task<ActionResult<IEnumerable<GamePartyMemberDTOGet>>> GetGamePartyMembersByGameId([FromRoute] Guid id)
        {

            try
            {
                return Ok(await _service.GetGamePartyMembers(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Current")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GamePartyMemberDTOGet>>> GetCurrentUserGamePartiesMember()
        {
            try
            {
                return Ok(await _service.GetCurrentUserGamePartiesMember(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GamePartyMemberDTOGet>> GetGamePartyMember(string id)
        {
            try
            {
                var gameParty = await _service.GetGamePartyMemberById(id);
                return Ok(gameParty);

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
        public async Task<ActionResult<Guid>> PostGamePartyMember(GamePartyMemberDTOAdd gamePartyMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not valid input");
            }
            try
            {
                return await _service.AddGamePartyMember(gamePartyMember);

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGamePartyMember(string id)
        {
            try
            {
                await _service.DeleteGamePartyMember(id);
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
