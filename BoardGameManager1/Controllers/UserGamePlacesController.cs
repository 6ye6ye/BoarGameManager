using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoardGamesManager.Data;
using DAL.Entities;
using BoardUserGameManager1.Services;
using BoardGameManager1.DTO;
using BoardUserGamePlaceManager1.Services;
using AutoMapper;
using System.Security.Claims;
using BoardGameManager1.Common.Exceptions;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGamePlacesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserGamePlaceService _service;

        public UserGamePlacesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _service = new UserGamePlaceService(context,mapper);
        }

        // GET: api/UserGamePlaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGamePlaceDTOGet>>> GetUsersGamePlaces()
        {
            try
            {
                return Ok(await _service.GetUserGamePlaces());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/UserGamePlaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGamePlaceDTOGet>> GetUserGamePlaceById(int id)
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

        // GET: api/UserGamePlaces/Current/5
        [Route("Current")]
        [HttpGet]
      
        public async Task<ActionResult<IEnumerable<CurrentUserGamePlaceDTOGet>>> GetCurrentUserGamePlaces()
        {
            try
            {
                var userGamePlace = await _service.GetCurrentUserGamePlaces(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return Ok(userGamePlace);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        //[Route("Current")]
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserGamePlaceDTOGet>> GetCurrentUserGamePlaceById(int id)
        //{     
        //    var userGamePlace = await _service.GetCurrentUserGamePlaceById(id, User.FindFirstValue(ClaimTypes.NameIdentifier));

        //    if (userGamePlace == null)
        //    {
        //        return NotFound();
        //    }

        //    return userGamePlace;
        //}



        // PUT: api/UserGamePlaces/5
      //  [Route("Current")]
        [HttpPatch("{id}")]

        public async Task<IActionResult> ChangeUserGamePlaceName(int id, string name)
        {
            try
            {
                await _service.ChangeUserGamePlaceName(id, name);
                return NoContent(); 
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

        // POST: api/UserGamePlaces
        [HttpPost]
        [Route("Current")]
        public async Task<ActionResult<CurrentUserGamePlaceDTOGet>> PostCurrentUserGamePlace([FromQuery] string name)
        {
            try
            {
                var newId = _service.AddUserGamePlace(name, User.FindFirstValue(ClaimTypes.NameIdentifier));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/UserGamePlaces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserGamePlace(int id)
        {     
            try
            {
                await _service.DeleteUserGamePlace(id);
                return NoContent();
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

     
    }
}
