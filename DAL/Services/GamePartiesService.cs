using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGamesManager.Data;
using DAL.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace BoardGamePartyManager1.Services
{
    public class GamePartiesService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GamePartiesService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GamePartyDTOGet>> GetGameParties(Guid userId)
        {
            var gamePartys = await _context.GameParties
                .Include(p => p.Game)
                .Include(p => p.PartyCreator)
                .Include(p => p.UserGamePlace)
                .Where(c => c.GamePartyMembers.Any(c => c.Player.AccountId == userId) || c.PartyCreatorId == userId)
                .ToListAsync();
            return _mapper.Map<List<GamePartyDTOGet>>(gamePartys).AsEnumerable();
        }

        //Get current  game parties where current user will be player
        public async Task<IEnumerable<GamePartyDTOGet>> GetCurrentUserGamePartiesPlayer(Guid id)
        {

            var gameParties = await _context.GameParties
                .Include(p => p.Game)
                .Include(p => p.PartyCreator)
                .Include(p => p.UserGamePlace)
                .Where(c => c.GamePartyMembers.Any(c => c.Player.AccountId == id))
                .ToListAsync();
            return _mapper.Map<List<GamePartyDTOGet>>(gameParties).AsEnumerable();
        }

        public async Task<IEnumerable<GamePartyDTOGet>> GetCurrentUserCreatedGameParties(Guid id)
        {
            var gamePartys = await _context.GameParties
                .Where(p => p.PartyCreatorId == id)
                 .Include(p => p.Game)
                .Include(p => p.PartyCreator)
                .Include(p => p.UserGamePlace)
                .ToListAsync();
            return _mapper.Map<List<GamePartyDTOGet>>(gamePartys).AsEnumerable();
        }

        public async Task<GamePartyDTOGet> GetGamePartyById(Guid id)
        {

            var gameParty = await _context.GameParties
                 .Include(p => p.Game)
                .Include(p => p.PartyCreator)
                .Include(p => p.UserGamePlace)
                .FirstAsync(g => g.Id == id);
            if (gameParty == null)
            {
                throw new NotFoundException("Game party");
            }
            return _mapper.Map<GamePartyDTOGet>(gameParty);
        }

        public async Task<Guid> AddGameParty(GamePartyDTOAdd gamePartyDTO, Guid userId)
        {
            var gameParty = _mapper.Map<GameParty>(gamePartyDTO);
            gameParty.PartyCreatorId = userId;
            _context.GameParties.Add(gameParty);
            await _context.SaveChangesAsync();
            return gameParty.Id;
        }

        public async Task DeleteGameParty(string id)
        {
            var gameParty = await _context.GameParties.FindAsync(new Guid(id));
            if (gameParty == null)
                throw new NotFoundException("Game party");
            _context.GameParties.Remove(gameParty);
            await _context.SaveChangesAsync();
        }

        private bool GamePartyExists(Guid id)
        {
            return _context.GameParties.Any(e => e.Id == id);
        }

        public async Task EditGameParty(string id, GamePartyDTOEdit gamePartyDTO)
        {
            var gameParty = await getGameParty(id);
            gameParty = _mapper.Map<GamePartyDTOEdit, GameParty>(gamePartyDTO, gameParty);
            _context.Entry(gameParty).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        private async Task<GameParty> getGameParty(string id)
        {
            var gameParty = await _context.GameParties.FindAsync(new Guid(id));
            if (gameParty == null)
                throw new NotFoundException("Game");
            return gameParty;
        }
    }
}
