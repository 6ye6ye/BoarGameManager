using AutoMapper;
using BoardGameManager1;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.DTO;
using BoardGamesManager.Data;
using DAL.Entities;
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

        public async Task<IEnumerable<GamePartyDTOGet>> GetGameParties()
        {
            var gamePartys = await _context.GameParties
                .Include(p => p.Game)
                .ToListAsync();
            return _mapper.Map<List<GamePartyDTOGet>>(gamePartys).AsEnumerable();
        }

        //Get current  game parties where current user will be player
        public async Task<IEnumerable<GamePartyDTOGet>> GetCurrentUserGamePartiesPlayer(string id)
        {
            var gameParties = await _context.GameParties
                .Include(p => p.Game)
                .Include(p => p.GamePartyMembers)
                .Where(c => c.GamePartyMembers.Any(c=>c.Player.AccountId== id))
                .ToListAsync();
            return _mapper.Map<List<GamePartyDTOGet>>(gameParties).AsEnumerable();
        }

        public async Task<IEnumerable<GamePartyDTOGet>> GetCurrentUserCreatedGameParties(string id)
        {
            var gamePartys = await _context.GameParties
                .Where(p=>p.PartyCreatorId==id)
                .Include(p=>p.Game)
                .Include(p => p.GamePartyMembers)
                .ToListAsync();
            return _mapper.Map<List<GamePartyDTOGet>>(gamePartys).AsEnumerable();
        }

        public async Task<GamePartyDTOGet> GetGamePartyById(int id)
        {

            var gameParty = await _context.GameParties.FindAsync(id);
            if (gameParty == null)
            {
                throw new NotFoundException("Game party not founded");
            }
            return _mapper.Map<GamePartyDTOGet>(gameParty);
        }

        public async Task<int> AddGameParty(GamePartyDTOAdd gamePartyDTO,string userId)
        {
            var gameParty = _mapper.Map<GameParty>(gamePartyDTO);
            gameParty.PartyCreatorId = userId;
            _context.GameParties.Add(gameParty);
            await _context.SaveChangesAsync();
            return gameParty.Id;
        }

        //public async Task<GamePartyDTOEdit> EditGameParty(GamePartyDTOEdit gamePartyDTO)
        //{
        //    var gameParty = _mapper.Map<GameParty>(gamePartyDTO);
        //    _context.GameParties.Attach(gameParty);

        //    _context.Entry(gameParty).Property(a => a.Image).IsModified = true;
        //    _context.Entry(gameParty).Property(a => a.PlayersMinCount).IsModified = true;
        //    _context.Entry(gameParty).Property(a => a.PlayersMaxCount).IsModified = true;

        //    gameParty.ModifiedOn = DateTime.Now;
        //    account.ModifiedBy = 1;

        //    _context.SaveChanges();
        //}

        public async Task DeleteGameParty(int id)
        {
            var gameParty = await _context.GameParties.FindAsync(id);
            if (gameParty == null)
                throw new NotFoundException("Game party not founded");
            _context.GameParties.Remove(gameParty);
            await _context.SaveChangesAsync();
        }

        private bool GamePartyExists(int id)
        {
            return _context.GameParties.Any(e => e.Id == id);
        }

    
        public async Task EditGameParty(int id, GamePartyDTOEdit gamePartyDTO)
        {
            var gameParty = await getGameParty(id);
            gameParty = _mapper.Map<GamePartyDTOEdit, GameParty>(gamePartyDTO, gameParty);
            _context.Entry(gameParty).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        private async Task<GameParty> getGameParty(int id)
        {
            var gameParty = await _context.GameParties.FindAsync(id);
            if (gameParty == null)
                throw new NotFoundException("Game not found");
            return gameParty;
        }
    }
}
