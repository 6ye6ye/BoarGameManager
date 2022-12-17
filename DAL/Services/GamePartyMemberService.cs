using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGamesManager.Data;
using DAL.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace BoardGameManager1.Services
{
    public class GamePartyMemberService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GamePartyMemberService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
   
        public async Task<IEnumerable<GamePartyMemberDTOGet>> GetGamePartyMembers(Guid gamePartyId)
        {
            var gameParties = await _context.GamePartyMembers
                .Include(c => c.GameParty.Game)
                .Include(c => c.GameRole)
                .Include(c => c.Player)
                .Where(g => g.GamePartyId == gamePartyId)
                .Select(c => _mapper.Map<GamePartyMemberDTOGet>(c))
                .ToListAsync();
            return gameParties.AsEnumerable();
        }
   
        public async Task<GamePartyMemberDTOGet> GetGamePartyMemberById(Guid gamePartyMemberId)
        {
            var gameParties = await _context.GamePartyMembers.FindAsync(gamePartyMemberId);
            if (gameParties == null)
                throw new NotFoundException("Record");
            return _mapper.Map<GamePartyMemberDTOGet>(gameParties);
        }

        public async Task<IEnumerable<GamePartyMemberDTOGet>> GetCurrentUserGamePartiesMember(Guid userId)
        {
            var gameParties = await _context.GamePartyMembers
                .Where(m => m.Player.AccountId == userId)
                .Include(p => p.GameParty.Game)
                .ToListAsync();
            return _mapper.Map<List<GamePartyMemberDTOGet>>(gameParties).AsEnumerable();
        }

        public async Task<Guid> AddGamePartyMember(GamePartyMemberDTOAdd gamePartyMemberDTO)
        {
            var gamePartyMember = _mapper.Map<GamePartyMember>(gamePartyMemberDTO);
            _context.GamePartyMembers.Add(gamePartyMember);
            await _context.SaveChangesAsync();
            return gamePartyMember.Id;
        }

        public async Task DeleteGamePartyMember(string id)
        {
            var gamePartyMember = await _context.GamePartyMembers.FindAsync(new Guid(id));
            if (gamePartyMember == null)
                throw new NotFoundException("Game");
            _context.GamePartyMembers.Remove(gamePartyMember);
            await _context.SaveChangesAsync();
        }
    }
}
