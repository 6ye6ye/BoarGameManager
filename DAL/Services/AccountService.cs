using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;
using BoardGamesManager.Data;
using BoardPlayerManager1.Services;
using DAL.Entities;
using DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace BoardGameManager1.Services
{
    public class AccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AccountService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<string>> GetUserRoles(string id)
        {
            var user = await _context.Users.FindAsync(new Guid(id));
            return await _userManager.GetRolesAsync(user);
        }
        public async Task Register(AccountDTORegister registerDTO)
        {
            //var userRole = await _context.Roles.FirstOrDefaultAsync(e => e.Name == UserRoleEnum.User.ToString());
            //if (userRole == null)
            //    throw new NotFoundException("User role");
           
            var user = _mapper.Map<User>(registerDTO);
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, UserRoleEnum.User.ToString());
                await _signInManager.SignInAsync(user, false);
                var playerService = new PlayerService(_context, _mapper).AddPlayer(user);
            }
            else 
            {
                string errMesage = "";
                foreach (var ex in result.Errors)
                    errMesage += ex.Description+"\n";
                throw new Exception(errMesage);
            }
            
       
        }


        public async Task<SignInResult> PasswordSignIn(AccountDTOLogin loginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDTO.Login, loginDTO.Password, loginDTO.RememberMe, false);
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
