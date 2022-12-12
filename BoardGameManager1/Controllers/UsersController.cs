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
                return Ok(await _service.GetUsers());
        }

        [HttpGet]
        [AllowAnonymous]
        [AppAutorize(UserRoleEnum.Admin)]
        [Route("Filtered")]
        public async Task<ActionResult<IEnumerable<UserDTOGet>>> GetUsersWithFilters([FromQuery] UsersFilter filter)
        {
                return Ok(await _service.GetUsersWithFilters(filter));
        }

        [HttpGet]
        [Route("search/{name}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserDTOGet>>> GetFirstTenUsersByName(string name)
        {
                return Ok(await _service.GetFirstTenUsers(name, new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
                await _service.DeleteUser(id);
                return Ok();
        }
    }
}
