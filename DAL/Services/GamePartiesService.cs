using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGamesManager.Data;
using DAL.Common.Filters;
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

        public async Task<IEnumerable<GamePartyDTOGet>> GetGamePartiesByUser(Guid userId)
        {
            var gameParties =  await GetGamePartiesQueryableByUser(userId)
                .Select(c=> _mapper.Map<GamePartyDTOGet>(c))
                .ToListAsync();
            return  gameParties.AsEnumerable();
        }

        public async Task<IEnumerable<GamePartyDTOGet>> GetGamePartiesByUserWithFilter(GamePartiesFilter filter, Guid userId)
        {
            var gameParties = GetGamePartiesQueryableByUser(userId);
            return await FilterGameParties(filter, userId, gameParties)
                .Select(c => _mapper.Map<GamePartyDTOGet>(c)).ToListAsync();
         
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

        public async Task EditGameParty(GamePartyDTOEdit gamePartyDTO)
        {
            var gameParty = await getGameParty(gamePartyDTO.Id);
            gameParty = _mapper.Map<GamePartyDTOEdit, GameParty>(gamePartyDTO, gameParty);
            _context.Entry(gameParty).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        private async Task<GameParty> getGameParty(Guid id)
        {
            var gameParty = await _context.GameParties.FindAsync(id);
            if (gameParty == null)
                throw new NotFoundException("Game");
            return gameParty;
        }


        private IQueryable<GameParty> GetGamePartiesQueryableByUser(Guid userId)
        {
            return  _context.GameParties
                .Include(p => p.Game)
                .Include(p => p.PartyCreator)
                .Include(p => p.UserGamePlace)
                .Where(c => c.GamePartyMembers.Any(c => c.Player.AccountId == userId) || c.PartyCreatorId == userId);
        }

        private IQueryable<GameParty> FilterGameParties(GamePartiesFilter filter, Guid userId, IQueryable<GameParty> gameParties)
        {
            if (filter.PlayerId !=null)
                gameParties = gameParties.Where(g => g.GamePartyMembers.Any(g => g.PlayerId == filter.PlayerId));
            if (filter.GamePlaceId != null)
                gameParties = gameParties.Where(g => g.UserGamePlaceId == filter.GamePlaceId);
            if (filter.GameName != null)
                gameParties = gameParties.Where(g => g.Game.Name.StartsWith(filter.GameName));
            if (filter.Created == true)
                gameParties = gameParties.Where(g => g.PartyCreatorId==userId);
            else if (filter.Created == false)
                gameParties = gameParties.Where(g => g.PartyCreatorId != userId);
            if (filter.StartDate != null)
                gameParties = gameParties.Where(g => g.Date >= filter.StartDate);
            if (filter.EndDate != null)
                gameParties = gameParties.Where(g => g.Date <= filter.EndDate);
            return gameParties;
        }
    }
}
