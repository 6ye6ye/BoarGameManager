using AutoMapper;
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
                .Include(u => u.UserRoles)
                .ThenInclude(r => r.Role)

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
                  .Include(u => u.UserRoles)
                .ThenInclude(r => r.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<UserDTOGet>(user);
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDTOGet>> GetUsersWithFilters(UsersFilter filter)
        {
            var users = _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(u => u.Role)
                .AsQueryable();

            if (filter.Name != null)
                users = users.Where(g => g.UserName.StartsWith(filter.Name));
            if (filter.Email != null)
                users = users.Where(g => g.Email.StartsWith(filter.Email));
            if (filter.RoleId != null)
                users = users.Where(g => g.UserRoles.Any(r => r.RoleId == filter.RoleId));
            var rezult = await users.Select(c => _mapper.Map<UserDTOGet>(c)).ToListAsync();
            return rezult.AsEnumerable();
        }

    }
}
