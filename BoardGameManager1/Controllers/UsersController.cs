using AutoMapper;
using BoardGameManager1.Enums;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using BoardUserManager1.Services;
using DAL.Common.Filters;
using DAL.Entities;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly UserService _service;

        public UsersController(AppDbContext context, IMapper mapper)
        {
            _service = new UserService(context, mapper);
        }


        [HttpGet]
        [AppAutorize(UserRoleEnum.Admin)]
        public async Task<ActionResult<IEnumerable<UserDTOGet>>> GetUsers()
        {
            try
            {
                return Ok(await _service.GetUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [AppAutorize(UserRoleEnum.Admin)]
        [Route("Filtered")]
        public async Task<ActionResult<IEnumerable<UserDTOGet>>> GetUsersWithFilters([FromQuery] UsersFilter filter)
        {
            try
            {
                return Ok(await _service.GetUsersWithFilters(filter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("search/{name}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserDTOGet>>> GetFirstTenUsersByName(string name)
        {
            try
            {
                return Ok(await _service.GetFirstTenUsers(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserDTOGet>> GetUserById(Guid id)
        {
            var user = await _service.GetUserById(id);


            if (user == null)
            {
                return NotFound();
            }

            return user;
            //}

            //// POST: api/Users
            //[HttpPost]
            //public async Task<ActionResult<User>> PostUser(UserDTOAdd user)
            //{
            //    var newId = new UserService(_context, _mapper).AddUser(user);
            //    return CreatedAtAction("GetUser", new { id = newId }, user);
            //}



            //// DELETE: api/Users/5
            //[HttpDelete("{id}")]
            //public async Task<IActionResult> DeleteUser(int id)
            //{
            //    var user = await _context.Users.FindAsync(id);
            //    if (user == null)
            //    {
            //        return NotFound();
            //    }

            //    await new UserService(_context, _mapper).DeleteUser(user);

            //    return NoContent();
            //}

            //private bool UserExists(string id)
            //{
            //    return _context.Users.Any(e => e.Id == id);
            //}
        }
    }
}
