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
            return Ok(await _service.GetGamePartyMembers(id));
        }

        [HttpGet]
        [Route("Current")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GamePartyMemberDTOGet>>> GetCurrentUserGamePartiesMember()
        {
            return Ok(await _service.GetCurrentUserGamePartiesMember(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GamePartyMemberDTOGet>> GetGamePartyMember(Guid id)
        {
            var gameParty = await _service.GetGamePartyMemberById(id);
            return Ok(gameParty);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> PostGamePartyMember(GamePartyMemberDTOAdd gamePartyMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not valid input");
            }
            return await _service.AddGamePartyMember(gamePartyMember);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGamePartyMember(string id)
        {
            await _service.DeleteGamePartyMember(id);
            return Ok();
        }
    }
}
