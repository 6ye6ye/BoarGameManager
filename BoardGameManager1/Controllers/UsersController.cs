using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoardGamesManager.Data;
using DAL.Entities;
using BoardUserManager1.Services;
using BoardGameManager1.Services;
using BoardGameManager1.DTO;
using AutoMapper;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTOGet>>> GetUsers()
        {
            try
            {
                return Ok(await new UserService(_context, _mapper).GetUsers());
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
            var user = await new UserService(_context, _mapper).GetUserById(id);


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

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await new UserService(_context, _mapper).DeleteUser(user);

            return NoContent();
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
