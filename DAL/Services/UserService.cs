using AutoMapper;
using BoardGameManager1.Entities;
using BoardGamesManager.Data;
using DAL.Common.Filters;
using DAL.Entities;
using DTO;
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
            var users = await _context.Users
                .Include(u => u.Roles)
                .ToListAsync();
            return _mapper.Map<List<UserDTOGet>>(users).AsEnumerable();
        }


        public async Task<IEnumerable<UserDTOGetShort>> GetFirstTenUsers(string userName)
        {
            var users = await _context.Users
                .Where(u => u.UserName.StartsWith(userName))
                .Take(10)
                .Select(u => _mapper.Map<UserDTOGetShort>(u))
                .ToListAsync();
            return users.AsEnumerable();
        }


        public async Task<UserDTOGet> GetUserById(Guid id)
        {
            var user = await _context.Users
                // .Include(u=>u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
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


        public async Task<IEnumerable<UserDTOGet>> GetUsersWithFilters(UsersFilter filter)
        {
            var users = _context.Users.AsQueryable();

            if (filter.Name != null)
                users = users.Where(g => g.UserName.StartsWith(filter.Name));
            if (filter.Email != null)
                users = users.Where(g => g.Email.StartsWith(filter.Email));
            if (filter.RoleId != null)
                users = users.Where(g => g.Roles.Any(r => r.Id == filter.RoleId));
            //    var usersRoles= _context.UserRoles.Where(r=>r.RoleId== filter.RoleId)
            //    users = users.Join(usersRoles,
            //        u=>u.Id,
            //        r=>r.UserId,
            //        (u, r) => new
            //        {
            //            u.Id,

            //        }
            //        ) Where(g => usersRoles.);
            //}


            var rezult = await users.Select(c => _mapper.Map<UserDTOGet>(c)).ToListAsync();
            return rezult.AsEnumerable();
        }

    }
}
