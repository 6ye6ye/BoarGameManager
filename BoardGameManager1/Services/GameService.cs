using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.DTO;
using BoardGameManager1.Entities;
using BoardGamesManager.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

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

        public  async Task<IEnumerable<GameDTOGet>> GetGames()
        {
            var games = await _context.Games.ToListAsync();
            return  _mapper.Map<List<GameDTOGet>>(games).AsEnumerable();
        }
        
        public async Task<GameDTOGet> GetGameById(int id)
        {
            var game = await getGame(id);
            return _mapper.Map<GameDTOGet>(game);
        }

        public async Task<ActionResult<int>> AddGame(GameDTOAdd gameDTO)
        {
            var game = _mapper.Map<Game>(gameDTO);
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }
        public async Task EditGame(int id,GameDTOEdit gameDTO)
        {
            var game = await getGame(id);
            game = _mapper.Map<GameDTOEdit, Game>(gameDTO, game);
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();     
        }
        public async Task DeleteGame(int id)
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


        public async Task<double> GetCurrentUserGameRate(int gameId,string userId)
        {
           
            var userGameRate= _context.GameRates.FirstOrDefault(g => g.UserId == userId && g.GameId == gameId);
            if (userGameRate == null)
                throw new NotFoundException("Rate not found");
            return userGameRate.Rate;
        }

        public async Task<double> PostCurrentUserGameRate(int gameId, int rate, string userId)
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


        private async Task<Game> getGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                throw new NotFoundException("Game not found");
            return  game;
        }
    }
}
