using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGamesManager.Data;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //public async Task<IEnumerable<RoleDTOGet>> GetGameRolesByGameId(int id)
        //{
        //    var gameRole = await _context.GameRoles.Where(g => g.GameId == id).ToListAsync();
        //    return _mapper.Map<List<RoleDTOGet>>(gameRole).AsEnumerable();
        //}

        //public async Task<GameRoleDTOGet> GetGameRoleById(int id)
        //{
        //    var gameRole = await _context.GameRoles
        //        .FindAsync(id);
        //    //var user = await _context.Users.FindAsync(id);
        //    if (gameRole == null)
        //        throw new NotFoundException("Game role");
        //    return _mapper.Map<GameRoleDTOGet>(gameRole);
        //}
    }
}
