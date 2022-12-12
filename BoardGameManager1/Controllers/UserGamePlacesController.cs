using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGamesManager.Data;
using BoardUserGamePlaceManager1.Services;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserGamePlacesController : ControllerBase
    {
        private readonly UserGamePlaceService _service;

        public UserGamePlacesController(AppDbContext context, IMapper mapper)
        {
            _service = new UserGamePlaceService(context, mapper);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserGamePlaceDTOGet>> GetUserGamePlaceById(string id)
        {
            return await _service.GetUserGamePlaceById(id);
        }

        [HttpGet]
        [Route("short")]
        public async Task<ActionResult<IEnumerable<UserGamePlaceDTOGetShort>>> GetCurrentUserGamePlaces()
        {
            var userGamePlace = await _service.GetCurrentUserGamePlaces(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            return Ok(userGamePlace);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> ChangeUserGamePlaceName(string id, string name)
        {
            await _service.ChangeUserGamePlaceName(id, name);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<UserGamePlaceDTOGetShort>> PostCurrentUserGamePlace([FromBody] UserGamePlaceDTOAdd gamePlace)
        {
            var newId = await _service.AddUserGamePlace(gamePlace.Name, new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserGamePlace(string id)
        {
            await _service.DeleteUserGamePlace(id);
            return Ok();
        }


        //// GET: api/UserGamePlaces
        //[HttpGet]
        //[AppAutorize(UserRoleEnum.Admin)]
        //public async Task<ActionResult<IEnumerable<UserGamePlaceDTOGet>>> GetUsersGamePlaces()
        //{
        //    try
        //    {
        //        return Ok(await _service.GetUserGamePlaces());
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpGet]
        //[Route("short")]
        //[AppAutorize(UserRoleEnum.Admin)]
        //public async Task<ActionResult<IEnumerable<UserGamePlaceDTOGetShort>>> GetUsersGamePlacesShort()
        //{
        //    try
        //    {
        //        return Ok(await _service.GetUserGamePlaces());
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
