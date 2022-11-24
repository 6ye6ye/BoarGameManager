using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;

using BoardGamesManager.Data;
using DAL.Services;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AppAutorize(UserRoleEnum.Admin)]
    public class RolesController : ControllerBase
    {

        private readonly RolesService _service;

        public RolesController(AppDbContext context, IMapper mapper)
        {

            _service = new RolesService(context, mapper);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTOGet>>> GetRoles()
        {
            try
            {
                var roles = await _service.GetRoles();
                return Ok(roles);

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

        // GET: api/GameParties/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<RoleDTOGet>> GetRoleById(int id)
        //{
        //    try
        //    {
        //        var gameParty = await _service.GetRo(id);
        //        return gameParty;

        //    }
        //    catch (NotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
