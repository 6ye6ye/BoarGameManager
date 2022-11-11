using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.DTO;
using BoardGameManager1.Entities;
using BoardGamesManager.Data;
using DAL.Entities;
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

        public async Task<double> GetCurrentUserGameRate(int gameId, string userId)
        {
            var userGameRate = _context.GameRates.FirstOrDefault(g => g.UserId == userId && g.GameId == gameId);
            if (userGameRate == null)
                throw new NotFoundException("Rate not found");
            return userGameRate.Rate;
        }
        public async Task<IEnumerable<GameRateDTOGet>>  GetGamesRates()
        {
            var gameRole = await _context.GameRoles.ToListAsync();
            return _mapper.Map<List<GameRateDTOGet>>(gameRole).AsEnumerable();
        }

        public async Task<double> AddCurrentUserGameRate(int gameId, int rate, string userId)
        {
            var game = await getGame(gameId);
            var userGameRate = _context.GameRates.FirstOrDefault(g => g.UserId == userId && g.GameId == gameId);

            //if already rated change user game rate
            if (userGameRate != null &&  rate != userGameRate.Rate)
            {
                userGameRate.Rate = rate;
                _context.GameRates.Update(userGameRate);
            }
            //if not rated, add new rate
            else
            {
                _context.GameRates.Add(new GameRate() { GameId = gameId, Rate = rate, UserId = userId });
            }
            await _context.SaveChangesAsync();
            await UpdateGameRate(game);
            return game.Rating;
        }
        public async Task<double> EditCurrentUserGameRate(int gameId, int rate, string userId)
        {
            var game = await getGame(gameId);
            var userGameRate = _context.GameRates.FirstOrDefault(g => g.UserId == userId && g.GameId == gameId);

            if (userGameRate == null)
                throw new NotFoundException("Rate not found");
            if (userGameRate.Rate == rate)
                return rate;

            userGameRate.Rate = rate;
            _context.GameRates.Update(userGameRate);
            await _context.SaveChangesAsync();
            await UpdateGameRate(game);
            return game.Rating;
        }

    
      

        private async Task UpdateGameRate(Game game)
        {
            var gameRates = _context.GameRates.Where(g => g.GameId == game.Id);
            game.RatingCount = gameRates.Count();
            game.Rating = (gameRates.Sum(c => c.Rate) / game.RatingCount);
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }
        private async Task<Game> getGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                throw new NotFoundException("Game not found");
            return game;
        }
    }
}
