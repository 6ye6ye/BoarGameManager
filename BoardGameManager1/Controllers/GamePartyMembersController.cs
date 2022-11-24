using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using DAL.Entities;
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
        //private readonly AppDbContext _context;
        //private readonly IMapper _mapper;
        private readonly GamePartyMemberService _service;

        public GamePartyMembersController(AppDbContext context, IMapper mapper)
        {
            //_context = context;
            //_mapper = mapper;
            _service = new GamePartyMemberService(context, mapper);
        }

        // GET: api/GamePartyMembers

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

        // GET: api/GamePartyMembers/5
        [HttpGet("{id}")]

        public async Task<ActionResult<GamePartyMemberDTOGet>> GetGamePartyMember(Guid id)
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



        // POST: api/GamePartyMembers
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

        // DELETE: api/GamePartyMembers/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteGamePartyMember(Guid id)
        {
            try
            {
                await _service.DeleteGamePartyMember(id);
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
