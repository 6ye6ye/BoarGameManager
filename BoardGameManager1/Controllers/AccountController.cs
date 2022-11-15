using BoardGameManager1.Enums;
using BoardGameManager1.Services;
using BoardGamesManager.Data;
using DAL.Entities;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoardGameManager1.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;
        //private readonly AppDbContext _context;
        //private readonly IMapper _mapper;
        private readonly AccountService _accountService;

        public AccountController(AutoMapper.IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager,AppDbContext context)
        {
            //_userManager = userManager;
            //_signInManager = signInManager;
            //_context = context;
            //_mapper = mapper;
            _accountService = new AccountService(mapper, userManager, signInManager, context);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] AccountDTORegister registerDTO)
        {
            if (ModelState.IsValid)
            {
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
                    return BadRequest("No user with this password and login");
                }
            }
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return Ok("Logout");
            
        }
    }
}
