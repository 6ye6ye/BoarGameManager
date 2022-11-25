using AutoMapper;
using BoardGamesManager.Data;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
    public class RolesService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public RolesService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDTOGet>> GetRoles()
        {
            var gameRoles = await _context.Roles.Select(r => _mapper.Map<RoleDTOGet>(r)).ToListAsync();
            return gameRoles.AsEnumerable();
        }
    }
}
