using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;
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

        //private readonly AppDbContext _context;
        //private readonly IMapper _mapper;
        private readonly UserFriendService _service;
        public UserFriendsController(AppDbContext context, IMapper mapper)
        {
            //_context = context;
            //_mapper = mapper;
            _service = new UserFriendService(context, mapper);
        }

        // GET: api/UserFriends
        [HttpGet()]
        [Route("Current")]
        public async Task<ActionResult<IEnumerable<UserFriendDTOGet>>> GetUserFriendsByCurrentUserId()
        {
            try
            {
                return Ok(await _service.GetUserFriendsByUserId(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/UserFriends/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserFriendDTOGet>>> GetUserFriendsById(string id)
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
        public async Task<ActionResult<UserFriend>> PostUserFriend(UserFriendDTOAdd userFriend)
        {
            // _context.UserFriends.Add(userFriend);
            try
            {
                var id = await _service.AddUserFriend(userFriend);
                return CreatedAtAction("GetUserFriend", new { id = id }, userFriend);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/UserFriends/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserFriend(int id)
        {
            try
            {
                return Ok( _service.DeleteUserFriend(id));
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
