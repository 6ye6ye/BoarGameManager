
using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Entities;
using BoardGamesManager.Data;
using DAL.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace BoardUserGamePlaceManager1.Services
{
    public class UserGamePlaceService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserGamePlaceService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserGamePlaceDTOGet>> GetUserGamePlaces()
        {
            var userGamePlaces = await _context.UserGamePlaces.ToListAsync();
            return _mapper.Map<List<UserGamePlaceDTOGet>>(userGamePlaces).AsEnumerable();
        }


        public async Task<UserGamePlaceDTOGet> GetUserGamePlaceById(Guid id)
        {
            var userGamePlace = await GetById(id);
            if (userGamePlace == null)
                throw new NotFoundException("Game place");
            return _mapper.Map<UserGamePlaceDTOGet>(userGamePlace);
        }

        public async Task<UserGamePlaceDTOGetShort> GetUserGamePlaceShortById(Guid id)
        {
            var userGamePlace = await GetById(id);

            return _mapper.Map<UserGamePlaceDTOGetShort>(userGamePlace);
        }

        public async Task<IEnumerable<UserGamePlaceDTOGetShort>> GetCurrentUserGamePlaces(Guid userId)
        {
            var userGamePlaces = await _context.UserGamePlaces.Where(p => p.UserId == userId).ToListAsync();
            return _mapper.Map<List<UserGamePlaceDTOGetShort>>(userGamePlaces).AsEnumerable();
        }

        public async Task<UserGamePlaceDTOGetShort> GetCurrentUserGamePlaceById(Guid placeId, Guid userId)
        {
            var userGamePlace = await _context.UserGamePlaces.FirstOrDefaultAsync(c => c.UserId == userId && c.Id == placeId);
            return _mapper.Map<UserGamePlaceDTOGetShort>(userGamePlace);
        }

        public async Task<Guid> AddUserGamePlace(string name, Guid userId)
        {
            var gamePlace = await _context.UserGamePlaces.FirstOrDefaultAsync(g => g.UserId == userId && g.Name == name);
            if (gamePlace != null)
                throw new DoublicateException(name);
            gamePlace = new UserGamePlace() { Name = name, UserId = userId };
            _context.UserGamePlaces.Add(gamePlace);
            await _context.SaveChangesAsync();
            return gamePlace.Id;
        }

        public async Task DeleteUserGamePlace(Guid id)
        {
            var userGamePlace = await GetById(id);
            _context.UserGamePlaces.Remove(userGamePlace);
            await _context.SaveChangesAsync();
        }

        public async Task EditUserGamePlace(UserGamePlaceDTOEdit userGamePlaceDTo)
        {
            var gamePlace = await GetById(userGamePlaceDTo.Id);
            gamePlace = _mapper.Map(userGamePlaceDTo, gamePlace);
            _context.Entry(gamePlace).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        private bool UserGamePlaceExists(Guid id)
        {
            return _context.UserGamePlaces.Any(e => e.Id == id);
        }

        private async Task<UserGamePlace> GetById(Guid id)
        {
            var gamePlace= await _context.UserGamePlaces.FindAsync( id);
            if (gamePlace == null)
                throw new NotFoundException("Game place");
            return gamePlace;
        }

    }
}
