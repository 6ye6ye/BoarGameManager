using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Entities;
using BoardGameManager1.Enums;
using BoardGamesManager.Data;
using DAL.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BoardPlayerManager1.Services
{
    public class PlayerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public PlayerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerDTOGet>> GetPlayersForCurrentUser(Guid userId)
        {
            var userFriendsId = await _context.UserFriends
                .Where(u => (u.InRequestUserId == userId || u.OutRequestUserId == userId) && u.Status == FriendStatus.Added)
                .Select(c => c.InRequestUserId == userId ? c.OutRequestUser.Id : c.InRequestUser.Id)
                .ToListAsync();
            var players = await _context.Players
                .Where(p => p.AccountId == userId || p.CreatorId == userId || (p.AccountId != null && userFriendsId.Contains((Guid)p.AccountId)))
                .Select(p => _mapper.Map<PlayerDTOGet>(p))
                .ToListAsync();
            return players.AsEnumerable();
        }

        public async Task<IEnumerable<PlayerDTOGetShort>> GetCreatedPlayersForCurrentUser(Guid userId)
        {
            var players = await _context.Players
                .Where(p => p.CreatorId == userId)
                .Select(p => _mapper.Map<PlayerDTOGetShort>(p))
                .ToListAsync();
            return players.AsEnumerable();
        }

        public async Task<PlayerDTOGetShort> GetPlayerShortById(Guid id)
        {
            var player = await _context.Players.FindAsync(id);
            return _mapper.Map<PlayerDTOGetShort>(player);
        }

        public async Task<PlayerDTOGet> GetPlayerById(string id)
        {
            var player = await _context.Players.FindAsync(new Guid(id));
            if (player == null)
                throw new NotFoundException("Player");
            return _mapper.Map<PlayerDTOGet>(player);
        }

        public async Task<Guid> AddPlayerToCurrentUser(PlayerDTOAdd playerDto)
        {
            var player = new Player() { CreatorId = new Guid(playerDto.CreatorId), Name = playerDto.Name };
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player.Id;
        }

        public async Task EditPlayerName(PlayerDTOEdit playerDto)
        {
            var player = await _context.Players.FindAsync(playerDto.Id);
             player = _mapper.Map<PlayerDTOEdit,Player> (playerDto, player);
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlayer(Guid id)
        {
            var player = _context.Players.Find(id);
            if (player == null)
                throw new NotFoundException("player");
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }
        public async Task AddPlayer(User user)
        {
            var player = new Player() { AccountId = user.Id, Name = user.UserName };
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
        }
    }
}
