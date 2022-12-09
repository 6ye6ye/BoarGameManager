using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;
using BoardGamesManager.Data;
using BoardUserManager1.Services;
using DAL.Common.Filters;
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
                return Ok(await _service.GetFirstTenUsers(name, new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
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
        }
        [HttpGet]
        [Route("Current")]
        [Authorize]
        public async Task<ActionResult<UserDTOGet>> GetCurrentUser()
        {
            var user = await _service.GetUserById(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _service.DeleteUser(id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

    }
}
