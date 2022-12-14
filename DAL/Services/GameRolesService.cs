using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Entities;
using BoardGamesManager.Data;
using DAL.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace BoardGameManager1.Services
{
    public class GameRolesService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public GameRolesService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameRoleDTOGet>> GetGameRoles()
        {
            var gameRole = await _context.GameRoles.ToListAsync();
            return _mapper.Map<List<GameRoleDTOGet>>(gameRole).AsEnumerable();
        }

        public async Task<IEnumerable<GameRoleDTOGet>> GetGameRolesByGameId(Guid id)
        {
            var gameRole = await _context.GameRoles.Where(g => g.GameId == id).ToListAsync();
            return _mapper.Map<List<GameRoleDTOGet>>(gameRole).AsEnumerable();
        }

        public async Task<GameRoleDTOGet> GetGameRoleById(string id)
        {
            var gameRole = await _context.GameRoles.FindAsync(new Guid(id));
            //var user = await _context.Users.FindAsync(id);
            if (gameRole == null)
                throw new NotFoundException("Game role");
            return _mapper.Map<GameRoleDTOGet>(gameRole);
        }

        public async Task<Guid> AddGameRole(GameRoleDTOAdd gameRoleDTO)
        {
            var gameRole = await _context.GameRoles.FirstOrDefaultAsync(g => g.GameId == gameRoleDTO.GameId && g.Name == gameRoleDTO.Name);
            if (gameRole != null)
                throw new DoublicateException(gameRoleDTO.Name);
             gameRole = _mapper.Map<GameRole>(gameRoleDTO);
            _context.GameRoles.Add(gameRole);
            await _context.SaveChangesAsync();
            return gameRole.Id;
        }

        public async Task EditGameRole(GameRoleDTOEdit gameRoleDTO)
        {
            var gameRole = _mapper.Map<GameRole>(gameRoleDTO);
            _context.Entry(gameRole).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameRole(Guid id)
        {
            var gameRole = _context.GameRoles.Find(id);
            if (gameRole == null)
                throw new NotFoundException("Game role");
            _context.GameRoles.Remove(gameRole);
            await _context.SaveChangesAsync();
        }

    }
}
