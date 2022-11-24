using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using BoardUserFriendManager1.Services;
using DAL;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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

        // GET: api/UserFriends
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

        // GET: api/UserFriends/5
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

        // POST: api/UserFriends
        [HttpPost]
        public async Task<ActionResult<Guid>> PostUserFriend(UserFriendDTOAdd userFriend)
        {
            // _context.UserFriends.Add(userFriend);
            try
            {
                return await _service.AddUserFriend(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)), userFriend.OutRequestUser);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("Accept/{id}")]
        [Authorize]
        public async Task<IActionResult> AcceptRequest(Guid id)
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
        public async Task<IActionResult> IgnoreRequest(Guid id)
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

        // DELETE: api/UserFriends/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserFriend(Guid id)
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

        //TODOOOOO
        //   [HttpDelete()]
        ////   [Route("status")]
        //   public async Task<IActionResult> ChangeFriendStatus(int id, [FromQuery] FriendStatus status)
        //   {
        //       var userFriend = await _context.UserFriends.FindAsync(id);
        //       if (userFriend == null)
        //       {
        //           return NotFound();
        //       }

        //       _context.UserFriends.Remove(userFriend);
        //       await _context.SaveChangesAsync();

        //       return NoContent();
        //   }

        //   private bool UserFriendExists(int id)
        //   {
        //       return _context.UserFriends.Any(e => e.Id == id);
        //   }
    }
}
