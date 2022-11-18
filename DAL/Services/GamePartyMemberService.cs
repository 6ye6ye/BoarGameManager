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
        #region ForAdmin
       
        public async Task<IEnumerable<GamePartyMemberDTOGet>> GetGamePartyMembers(int gamePartyId)
        {
            var gameParties = await _context.GamePartyMembers
                .Include(c=>c.GameParty.Game)
                .Include(c=>c.GameRole)
                .Include(c=>c.Player)
                .Where(g=>g.GamePartyId== gamePartyId)
                .Select( c => _mapper.Map<GamePartyMemberDTOGet>(c))
                .ToListAsync();
            return gameParties.AsEnumerable();
        }
        #endregion

        #region ForloggedUsers

        //-------------------------------------------------------
        public async Task<GamePartyMemberDTOGet> GetGamePartyMemberById(int gamePartyMemberId)
        {
            var gameParties = await _context.GamePartyMembers.FindAsync(gamePartyMemberId);
            if (gameParties == null)
                throw new NotFoundException("Record");
            return _mapper.Map<GamePartyMemberDTOGet>(gameParties);
        }

        public async Task<IEnumerable<GamePartyMemberDTOGet>> GetCurrentUserGamePartiesMember(string userId)
        {
            var gameParties = await _context.GamePartyMembers
                .Where(m => m.Player.AccountId == userId)
                .Include(p => p.GameParty.Game)
                .ToListAsync();
            return _mapper.Map<List<GamePartyMemberDTOGet>>(gameParties).AsEnumerable();
        }

    
        
        //public async Task<GamePartyDTOGet> GetGamePartyById(int id)
        //{

        //    var gameParty = await _context.GameParties.FindAsync(id);
        //    if (gameParty == null)
        //    {
        //        throw new NotFoundException("Game party not founded");
        //    }
        //    return _mapper.Map<GamePartyDTOGet>(gameParty);
        //}

        public async Task<int> AddGamePartyMember(GamePartyMemberDTOAdd gamePartyMemberDTO)
        {
            var gamePartyMember = _mapper.Map<GamePartyMember>(gamePartyMemberDTO);
            _context.GamePartyMembers.Add(gamePartyMember);
            await _context.SaveChangesAsync();
            return gamePartyMember.Id;
        }

        public async Task DeleteGamePartyMember(int id)
        {
            var gamePartyMember = await _context.GamePartyMembers.FindAsync(id);
            if (gamePartyMember == null)
                throw new NotFoundException("Game");
            _context.GamePartyMembers.Remove(gamePartyMember);
            await _context.SaveChangesAsync();
        }

        private bool GamePartyExists(int id)
        {
            return _context.GameParties.Any(e => e.Id == id);
        }
        #endregion

        private bool GamePartyMemberExists(int id)
        {
            return _context.GamePartyMembers.Any(e => e.Id == id);
        }
    }
}
