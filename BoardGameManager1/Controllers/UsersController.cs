using AutoMapper;
using BoardGameManager1.Enums;
using BoardGamesManager.Data;
using BoardUserManager1.Services;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AppAutorize(UserRoleEnum.Admin)]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;

        public UsersController(AppDbContext context, IMapper mapper)
        {
            _service = new UserService(context, mapper);
        }

        // GET: api/Users
        [HttpGet]
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

        // GET: api/Users
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<UserDTOGet>>> GetFirstTenUsersByName(UserDTOGetByName userDto)
        {
            try
            {
                return Ok(await _service.GetFirstTenUsers(userDto.UserName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTOGet>> GetUser(string id)
        {
            var user = await _service.GetUserById(id);


            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        //// PUT: api/Users/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(string id, [FromBody] UserDTOEdit user)
        //{
       
        //    try
        //    {
        //        //TODO
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Users
        //[HttpPost]
        //public async Task<ActionResult<User>> PostUser(UserDTOAdd user)
        //{
        //    var newId = new UserService(_context, _mapper).AddUser(user);
        //    return CreatedAtAction("GetUser", new { id = newId }, user);
        //}
        

        //TODOOOOOOO

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
