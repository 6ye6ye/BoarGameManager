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
            try
            {
                return Ok(await _service.GetUserFriendsByUserId(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        [Route("IncomingRequests")]
        public async Task<ActionResult<IEnumerable<UserFriendDTOGet>>> GetUserIncomingRequestsByCurrentUserId()
        {
            try
            {
                return Ok(await _service.GetUserFriendIncomingRequests(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        [Route("OutRequests")]
        public async Task<ActionResult<IEnumerable<UserFriendDTOGet>>> GetUserOutRequestsByCurrentUserId()
        {
            try
            {
                return Ok(await _service.GetUserFriendOutRequests(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserFriendDTOGet>>> GetUserFriendsById(Guid id)
        {
            try
            {
                var userFriend = await _service.GetUserFriendsByUserId(id);
                return Ok(userFriend);
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> PostUserFriend(UserFriendDTOAdd userFriend)
        {
            try
            {
                return await _service.AddUserFriend(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)), new Guid(userFriend.OutRequestUser));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Accept/{id}")]
        [Authorize]
        public async Task<IActionResult> AcceptRequest(string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AcceptUserFriend(id);
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
            return BadRequest("Is not valid");
        }

        [HttpPut]
        [Route("Ignore/{id}")]
        [Authorize]
        public async Task<IActionResult> IgnoreRequest(string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.IgnoreUserFriend(id);
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
            return BadRequest("Is not valid");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserFriend(string id)
        {
            try
            {
                await _service.DeleteUserFriend(id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
