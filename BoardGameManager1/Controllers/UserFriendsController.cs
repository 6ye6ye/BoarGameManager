using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGamesManager.Data;
using BoardUserFriendManager1.Services;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserFriendsController : ControllerBase
    {
        private readonly UserFriendService _service;
        public UserFriendsController(AppDbContext context, IMapper mapper)
        {
            _service = new UserFriendService(context, mapper);
        }

        [HttpGet()]
        [Route("Friends")]
        public async Task<ActionResult<IEnumerable<UserFriendDTOGet>>> GetUserFriendsByCurrentUserId()
        {
            return Ok(await _service.GetUserFriendsByUserId(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }

        [HttpGet()]
        [Route("IncomingRequests")]
        public async Task<ActionResult<IEnumerable<UserFriendDTOGet>>> GetUserIncomingRequestsByCurrentUserId()
        {
            return Ok(await _service.GetUserFriendIncomingRequests(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }

        [HttpGet()]
        [Route("OutRequests")]
        public async Task<ActionResult<IEnumerable<UserFriendDTOGet>>> GetUserOutRequestsByCurrentUserId()
        {
            return Ok(await _service.GetUserFriendOutRequests(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserFriendDTOGet>>> GetUserFriendsById(Guid id)
        {
            var userFriend = await _service.GetUserFriendsByUserId(id);
            return Ok(userFriend);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> PostUserFriend(UserFriendDTOAdd userFriend)
        {
            return await _service.AddUserFriend(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)), new Guid(userFriend.OutRequestUser));
        }

        [HttpPut]
        [Route("Accept/{id}")]
        [Authorize]
        public async Task<IActionResult> AcceptRequest(string id)
        {
            if (ModelState.IsValid)
            {
                await _service.AcceptUserFriend(id);
                return Ok();

            }
            return BadRequest("Is not valid");
        }

        [HttpPut]
        [Route("Ignore/{id}")]
        [Authorize]
        public async Task<IActionResult> IgnoreRequest(string id)
        {
            if (ModelState.IsValid)
            {
                await _service.IgnoreUserFriend(id);
                return Ok();
            }
            return BadRequest("Is not valid");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserFriend(string id)
        {
            await _service.DeleteUserFriend(id);
            return Ok();
        }
    }
}
