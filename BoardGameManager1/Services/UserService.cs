using AutoMapper;
using BoardGameManager1.DTO;
using BoardGamesManager.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardUserManager1.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTOGet>> GetUsers()
        {
            var users =  await _context.Users
                //.Include(u => u.Role)
                .ToListAsync();
            return _mapper.Map<List<UserDTOGet>>(users).AsEnumerable();
        }

        public async Task<UserDTOGet> GetUserById(string id)
        {
            var user = await _context.Users
               // .Include(u=>u.Role)
                .FirstOrDefaultAsync(u=>u.Id==id);
           //var user = await _context.Users.FindAsync(id);
       
            return _mapper.Map<UserDTOGet>(user);
        }

        //public async Task<string> AddUser(UserDTOAdd userDTO)
        //{
        //    var user = _mapper.Map<User>(userDTO);
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();
        //    return user.Id;
        //}

        //public async Task<UserDTOEdit> EditUser(UserDTOEdit userDTO)
        //{
        //    var user = _mapper.Map<User>(userDTO);
        //    _context.Users.Attach(user);

        //    _context.Entry(user).Property(a => a.Image).IsModified = true;
        //    _context.Entry(user).Property(a => a.PlayersMinCount).IsModified = true;
        //    _context.Entry(user).Property(a => a.PlayersMaxCount).IsModified = true;

        //    user.ModifiedOn = DateTime.Now;
        //    account.ModifiedBy = 1;

        //    _context.SaveChanges();
        //}

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeRole(User user,int roleId)
        {
            //TODO
            //_context.Users.Remove(user);
            //await _context.SaveChangesAsync();
        }


    }
}
