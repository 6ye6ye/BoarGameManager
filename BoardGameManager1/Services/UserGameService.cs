using AutoMapper;
using BoardGameManager1;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.DTO;
using BoardGamesManager.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardUserGameManager1.Services
{
    public class UserGameService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public UserGameService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameDTOGet>> GetCurrentUserGames(string id)
        {
            var games = _context.UserGames
                .Where(g => g.UserId == id)
                .Include(g => g.User)
                .Select(g => _mapper.Map<GameDTOGet>(g.Game));
            return games.AsEnumerable();
        }

        public async Task<IEnumerable<UserGameDTOGet>> GetUsersGames()
        {
            var userGames = await _context.UserGames.ToListAsync();
            return _mapper.Map<List<UserGameDTOGet>>(userGames).AsEnumerable();
        }

        public async Task<UserGameDTOGet> GetUserGameById(int id)
        {
            var userGame = await getUserGame(id);
            return _mapper.Map<UserGameDTOGet>(userGame);
        }

        public async Task<int> AddCurrentUserGame(int gameId, string userId)
        {
            var userGame = await _context.UserGames.FirstOrDefaultAsync(g => g.UserId == userId && g.GameId == gameId);
            if (userGame != null)
                throw new DoublicateException("Game already added");
            userGame = new UserGame() { GameId= gameId, UserId = userId };
            _context.UserGames.Add(userGame);
            await _context.SaveChangesAsync();
            return userGame.Id;
        }

        //public async Task<UserGameDTOEdit> EditUserGame(UserGameDTOEdit userGameDTO)
        //{
        //    var userGame = _mapper.Map<UserGame>(userGameDTO);
        //    _context.UserGames.Attach(userGame);

        //    _context.Entry(userGame).Property(a => a.Image).IsModified = true;
        //    _context.Entry(userGame).Property(a => a.PlayersMinCount).IsModified = true;
        //    _context.Entry(userGame).Property(a => a.PlayersMaxCount).IsModified = true;

        //    userGame.ModifiedOn = DateTime.Now;
        //    account.ModifiedBy = 1;

        //    _context.SaveChanges();
        //}

        public async Task DeleteCurrentUserGame(string userId, int gameId)
        {
            var userGame = await getUserGame(userId, gameId);
            _context.UserGames.Remove(userGame);
            await _context.SaveChangesAsync();
        }

        private async Task<UserGame> getUserGame(int id)
        {
            var userGame = await _context.UserGames.FindAsync(id);
            if (userGame == null)
                throw new NotFoundException("Game not found");
            return userGame;
        }
        private async Task<UserGame> getUserGame(string userId, int gameId)
        {
            var userGame = await _context.UserGames.FirstAsync(u=>u.GameId==gameId&& u.UserId==userId);
            if (userGame == null)
                throw new NotFoundException("Game not found");
            return userGame;
        }

    }
}


