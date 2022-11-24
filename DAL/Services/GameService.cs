using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Entities;
using BoardGamesManager.Data;
using DAL.Common.Filters;
using DAL.Entities;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardGameManager1.Services
{
    public class GameService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public GameService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameDTOGetShort>> GetGamesShort()
        {
            var games = await _context.Games.Select(c => _mapper.Map<GameDTOGetShort>(c)).ToArrayAsync();
            return games.AsEnumerable();
        }

        public async Task<IEnumerable<GameDTOGet>> GetGamesWithFilters(GameFilter filter, Guid userId)
        {
            var games = _context.Games
                    .Include(c => c.UserGames).AsQueryable();
            if (filter.ShowAdded == true)
                games = games.Where(g => g.UserGames.Any(g => g.UserId == userId));
            if (filter.ReleaseYear != 0)
                games = games.Where(g => g.ReleaseYear == filter.ReleaseYear);
            if (filter.Name != null)
                games = games.Where(g => g.Name.StartsWith(filter.Name));
            if (filter.MinRate != 0)
                games = games.Where(g => g.Rating >= filter.MinRate);
            if (filter.MaxRate != 10)
                games = games.Where(g => g.Rating <= filter.MaxRate);
            var rezult = await games.Select(c => _mapper.Map<GameDTOGet>(c)).ToListAsync();
            return rezult.AsEnumerable();
        }

        public async Task<IEnumerable<GameDTOGet>> GetGames(Guid userId)
        {

            var games = await _context.Games
                     .Include(c => c.UserGames.Where(c => c.UserId == userId))
                     .Select(c => _mapper.Map<GameDTOGet>(c))
                     .ToListAsync();
            return games.AsEnumerable();
        }

        public async Task<GameDTOGet> GetGameById(Guid id)
        {
            var game = await getGame(id);
            return _mapper.Map<GameDTOGet>(game);
        }

        public async Task<ActionResult<Guid>> AddGame(GameDTOAdd gameDTO)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Name == gameDTO.Name);
            if (game != null)
                throw new DoublicateException("Game name");
            game = _mapper.Map<Game>(gameDTO);
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }
        public async Task EditGame(Guid id, GameDTOEdit gameDTO)
        {
            var game = await getGame(id);
            game = _mapper.Map<GameDTOEdit, Game>(gameDTO, game);
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteGame(Guid id)
        {
            var game = await getGame(id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }


        //public async Task<GameDTOEdit> EditGame(GameDTOEdit gameDTO)
        //{
        //    var game = _mapper.Map<Game>(gameDTO);
        //    _context.Games.Attach(game);

        //    _context.Entry(game).Property(a => a.Image).IsModified = true;
        //    _context.Entry(game).Property(a => a.PlayersMinCount).IsModified = true;
        //    _context.Entry(game).Property(a => a.PlayersMaxCount).IsModified = true;

        //    game.ModifiedOn = DateTime.Now;
        //    account.ModifiedBy = 1;

        //    _context.SaveChanges();
        //}


        public async Task<double> GetCurrentUserGameRate(Guid gameId, Guid userId)
        {

            var userGameRate = await _context.GameRates.FirstOrDefaultAsync(g => g.UserId == userId && g.GameId == gameId);
            if (userGameRate == null)
                throw new NotFoundException("Rate");
            return userGameRate.Rate;
        }

        public async Task<double> PostCurrentUserGameRate(Guid gameId, int rate, Guid userId)
        {
            var game = await getGame(gameId);
            var userGameRate = _context.GameRates.FirstOrDefault(g => g.UserId == userId && g.GameId == gameId);

            //if already rated change user game rate
            if (userGameRate != null || rate != userGameRate.Rate)
            {
                userGameRate.Rate = rate;
                _context.GameRates.Update(userGameRate);
            }
            //if not rated, add new rate
            else
            {
                _context.GameRates.Add(new GameRate() { GameId = gameId, Rate = rate, UserId = userId });
            }

            var gameRates = _context.GameRates.Where(g => g.GameId == gameId);

            game.RatingCount = gameRates.Count();
            game.Rating = (gameRates.Sum(c => c.Rate) / game.RatingCount);

            _context.Games.Update(game);
            await _context.SaveChangesAsync();

            return game.Rating;
        }


        private async Task<Game> getGame(Guid id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                throw new NotFoundException("Game");
            return game;
        }
    }
}
