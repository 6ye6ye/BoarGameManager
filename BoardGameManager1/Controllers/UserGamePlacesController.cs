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
            try
            {
                return await _service.GetUserGamePlaceById(id);
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

        [HttpGet]
        [Route("short")]
        public async Task<ActionResult<IEnumerable<UserGamePlaceDTOGetShort>>> GetCurrentUserGamePlaces()
        {
            try
            {
                var userGamePlace = await _service.GetCurrentUserGamePlaces(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                return Ok(userGamePlace);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> ChangeUserGamePlaceName(string id, string name)
        {
            try
            {
                await _service.ChangeUserGamePlaceName(id, name);
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

        [HttpPost]
        public async Task<ActionResult<UserGamePlaceDTOGetShort>> PostCurrentUserGamePlace([FromBody] UserGamePlaceDTOAdd gamePlace)
        {
            try
            {
                var newId = await _service.AddUserGamePlace(gamePlace.Name, new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserGamePlace(string id)
        {
            try
            {
                await _service.DeleteUserGamePlace(id);
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
