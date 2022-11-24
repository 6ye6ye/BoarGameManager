using BoardGameManager1.Entities;
using BoardGameManager1.Enums;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using DAL.Entities;
using DTO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGameManager1.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;


        public AccountController(AutoMapper.IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext context)
        {
            _accountService = new AccountService(mapper, userManager, signInManager, context);

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] AccountDTORegister registerDTO)
        {
            if (ModelState.IsValid)
            {
                if (registerDTO.PasswordRepeat != registerDTO.Password)
                    return ValidationProblem("Passwords are not the same");
                try
                {
                    await _accountService.Register(registerDTO);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("Model isn't valid");
        }
    
        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] AccountDTOLogin loginDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.PasswordSignIn(loginDTO);
                if (result.Succeeded)
                {
                    return Ok("Succeeded");
                }
                else
                {
                    return NotFound("No user with this password and login");
                }
            }
            return Ok();
        }

        [HttpPost]
        [Route("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            //  await HttpContext.SignOutAsync();
            await _accountService.Logout();
            return Ok();
        }

        [HttpGet]
        [Route("Role")]
        public async Task<ActionResult<IList<string>>> GetUserRole()
        {
            try
            {
                if (User.Identities.Any())
                {
                    return Ok(await _accountService.GetUserRoles(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                }
                return BadRequest("Need sign in");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("getId")]
        public string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpGet]
        [Authorize]
        [Route("userName")]
        public string GetCurrentUserName()
        {
            return User.Identity.Name;
        }
    }
}
