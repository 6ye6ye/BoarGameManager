using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Entities;
using BoardGamesManager.Data;
using DAL.Common.Filters;
using DAL.Entities;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

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
            var games = await _context.Games.OrderByDescending(c => c.Name).Select(c => _mapper.Map<GameDTOGetShort>(c)).ToArrayAsync();
            return games.AsEnumerable();
        }

        public async Task<IEnumerable<GameDTOGet>> GetGamesWithFilters(GameFilter filter, string userId)
        {
            var games = _context.Games
                    .Include(c => c.UserGames).AsQueryable();
            if (filter.ShowAdded == true)
                games = games.Where(g => g.UserGames.Any(g => g.UserId.ToString() == userId));
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

        public async Task<IEnumerable<GameDTOGet>> GetGames(string userId)
        {
            var games = await _context.Games
                     .Include(c => c.UserGames.Where(c => c.UserId.ToString() == userId))
                     .Select(c => _mapper.Map<GameDTOGet>(c))
                     .ToListAsync();
            return games.AsEnumerable();
        }

        public async Task<IEnumerable<GameDTOGet>> GetTopTenGames(string userId)
        {
            var games = await _context.Games
                     .Include(c => c.UserGames.Where(c => c.UserId.ToString() == userId))
                     .OrderByDescending(c => c.Rating)
                     .Take(10)
                     .Select(c => _mapper.Map<GameDTOGet>(c))
                     .ToListAsync();
            return games.AsEnumerable();
        }


        public async Task<GameDTOGet> GetGameById(string id)
        {
            var game = await getGame(id);
            return _mapper.Map<GameDTOGet>(game);
        }

        public async Task<ActionResult<Guid>> AddGame(GameDTOAdd gameDTO)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Name == gameDTO.Name);
            if (game != null)
                throw new DoublicateException(gameDTO.Name);
            game = _mapper.Map<Game>(gameDTO);
            game.DateAdded = DateTime.Now;

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return game.Id;
        }

        public async Task<ActionResult<Guid>> AddGame(Game game)
        {
            var gameExist = await _context.Games.FirstOrDefaultAsync(g => g.Name == game.Name);
            if (gameExist != null)
                throw new DoublicateException(game.Name);
            game.DateAdded = DateTime.Now;
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return game.Id;
        }

        public async Task<IEnumerable<GameDTOGet>> AddGames(IEnumerable<Game> games)
        {
            var teseraGames = await _context.Games.Select(c => c.TeseraId).ToListAsync();
            games = games.Where(g => !teseraGames.Contains(g.TeseraId));
            foreach (var game in games)
            {
                game.DateAdded = DateTime.Now;
                if (game.Image != null)
                    game.Image = await UploadImageFromUrl(game.Image, game.Alias);
                else
                    game.Image = "no-image-icon-6.png";
            }
            await _context.Games.AddRangeAsync(games);
            await _context.SaveChangesAsync();
            var count = games.Count();
            var mapped = _mapper.Map<IEnumerable<GameDTOGet>>(games);
            return mapped;
        }

        public async Task EditGame(GameDTOEdit gameDTO)
        {
            var game = _mapper.Map<Game>(gameDTO);
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGame(string id)
        {
            var game = await getGame(id);
            if (game.Image != "no-image-icon-6.png")
            {
                string Path = "../BoardGameManager1/wwwroot/images/" + game.Image;
                FileInfo file = new FileInfo(Path);
                if (file.Exists)
                {
                    File.Delete(Path);
                }
            }
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }

        public string UploadImageFromFile(IFormFile file)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", uniqueFileName);
            file.CopyTo(new FileStream(imagePath, FileMode.Create));
            return uniqueFileName;
        }
        public async Task<string> UploadImageFromUrl(string uri, string imageName)
        {
            var fileExtension = Path.GetExtension(uri);
            using (HttpClient client = new HttpClient())
            {
                var imageBytes = await client.GetByteArrayAsync(uri);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", imageName + fileExtension);
                //await File.WriteAllBytesAsync("wwwroot/images/", imageBytes);
                using (FileStream file = File.Create(imagePath)) //path = "wwwroot\\XML\\1.zip"
                    file.Write(imageBytes, 0, imageBytes.Length);
                // await new FileStream(imagePath, FileMode.Create).ReadAsync(imageBytes);
            }
            return imageName + fileExtension;
        }

        public async Task<double> GetCurrentUserGameRate(string gameId, string userId)
        {

            var userGameRate = await _context.GameRates.FirstOrDefaultAsync(g =>
                g.UserId.ToString() == userId && g.GameId.ToString() == gameId);
            if (userGameRate == null)
                throw new NotFoundException("Rate");
            return userGameRate.Rate;
        }

        public async Task<double> PostCurrentUserGameRate(string gameId, int rate, string userId)
        {
            var game = await getGame(gameId);
            var userGameRate = _context.GameRates.FirstOrDefault(g => g.UserId.ToString() == userId && g.GameId.ToString() == gameId);

            //if already rated change user game rate
            if (userGameRate != null || rate != userGameRate.Rate)
            {
                userGameRate.Rate = rate;
                _context.GameRates.Update(userGameRate);
            }
            //if not rated, add new rate
            else
            {
                _context.GameRates.Add(new GameRate() { GameId = new Guid(gameId), Rate = rate, UserId = new Guid(userId) });
            }

            var gameRates = _context.GameRates.Where(g => g.GameId.ToString() == gameId);

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
