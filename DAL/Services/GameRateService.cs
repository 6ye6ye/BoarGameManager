using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Entities;
using BoardGamesManager.Data;
using DAL.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace BoardGameManager1.Services
{
    public class GameRateService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GameRateService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameRateDTOGet>> GetGamesRates()
        {
            var gameRole = await _context.GameRoles.ToListAsync();
            return _mapper.Map<List<GameRateDTOGet>>(gameRole).AsEnumerable();
        }

        public async Task<double> GetGameRate(Guid gameId)
        {
            var userGameRate = _context.GameRates.FirstOrDefault(g => g.GameId == gameId);
            if (userGameRate == null)
                return 0;
            return userGameRate.Rate;
        }

        public async Task<double> GetCurrentUserGameRate(Guid gameId, Guid userId)
        {
            var userGameRate = _context.GameRates.FirstOrDefault(g => g.UserId == userId && g.GameId == gameId);
            if (userGameRate == null)
                return 0;
            return userGameRate.Rate;
        }

        //Return new game rating after edit
        public async Task<double> AddCurrentUserGameRate(Game game, int rate, Guid userId)
        {

            var userGameRate = _context.GameRates.FirstOrDefault(g => g.UserId == userId && g.GameId == game.Id);

            _context.GameRates.Add(new GameRate() { GameId = game.Id, Rate = rate, UserId = userId });

            await _context.SaveChangesAsync();
            await UpdateGameRate(game);
            return game.Rating;
        }

        // Return new game rating after edit
        public async Task<double> EditCurrentUserGameRate(string gameId, int rate, string userId)
        {
            var game = await getGame(gameId);
            var userGameRate = _context.GameRates.FirstOrDefault(g => g.UserId == new Guid(userId) && g.GameId == new Guid(gameId));

            if (userGameRate == null)
                return await AddCurrentUserGameRate(game, rate, new Guid(userId));
            if (userGameRate.Rate == rate)
                return game.Rating;

            userGameRate.Rate = rate;
            _context.GameRates.Update(userGameRate);
            await _context.SaveChangesAsync();
            return await UpdateGameRate(game);
        }

        //Return new game rating after edit
        private async Task<double> UpdateGameRate(Game game)
        {
            var gameRates = _context.GameRates.Where(g => g.GameId == game.Id);
            game.RatingCount = gameRates.Count();
            game.Rating = (gameRates.Sum(c => c.Rate) / game.RatingCount);
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
            return game.Rating;
        }
        private async Task<Game> getGame(string id)
        {
            var game = await _context.Games.FindAsync(new Guid(id));
            if (game == null)
                throw new NotFoundException("Game");
            return game;
        }
    }
}
