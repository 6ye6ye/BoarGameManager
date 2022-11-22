
using AutoMapper;
using BoardGameManager1.Common.Exceptions;
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


        //-------------------FOR ADMIN-----------------------

        public async Task<IEnumerable<UserGamePlaceDTOGet>> GetUserGamePlaces()
        {
            var userGamePlaces = await _context.UserGamePlaces.ToListAsync();
            return _mapper.Map<List<UserGamePlaceDTOGet>>(userGamePlaces).AsEnumerable();
        }

        public async Task<UserGamePlaceDTOGet> GetUserGamePlaceById(int id)
        {
            var userGamePlace = await _context.UserGamePlaces.FindAsync(id);
            if (userGamePlace==null)
            {
                throw new NotFoundException("Game place");
            }
            return _mapper.Map<UserGamePlaceDTOGet>(userGamePlace);
        }


        //----------------FOR logged users---------------------
    
        public async Task<IEnumerable<UserGamePlaceDTOGetShort>> GetCurrentUserGamePlaces(string userId)
        {
            var userGamePlaces = await _context.UserGamePlaces.Where(p=>p.UserId==userId).ToListAsync();
            return _mapper.Map<List<UserGamePlaceDTOGetShort>>(userGamePlaces).AsEnumerable();
        }


        public async Task<UserGamePlaceDTOGetShort> GetCurrentUserGamePlaceById(int placeId,string userId)
        {
            var userGamePlace = await _context.UserGamePlaces.FirstOrDefaultAsync(c=>c.UserId==userId&& c.Id==placeId);
            return _mapper.Map<UserGamePlaceDTOGetShort>(userGamePlace);
        }

        public async Task<int> AddUserGamePlace(string name,string userId)
        {
            var gamePlace = await _context.UserGamePlaces.FirstOrDefaultAsync(g => g.UserId == userId && g.Name == name);
            if (gamePlace != null)
                throw new DoublicateException("Game place");
            gamePlace= new UserGamePlace() { Name=name,UserId=userId};
            _context.UserGamePlaces.Add(gamePlace);
            await _context.SaveChangesAsync();
            return gamePlace.Id;
        }


        public async Task DeleteUserGamePlace(int id)
        {
            var userGamePlace = await _context.UserGamePlaces.FindAsync(id);
            if (userGamePlace == null)
            {
                throw new NotFoundException("Game place") ;
            }
            _context.UserGamePlaces.Remove(userGamePlace);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeUserGamePlaceName(int id, string name)
        {
            if (!UserGamePlaceExists(id))
            {
                throw new NotFoundException("Game place");
            }
            var gamePlace = await _context.UserGamePlaces.FindAsync(id);         
            gamePlace.Name = name;
            _context.Entry(gamePlace).State = EntityState.Modified;
            _context.SaveChanges();
        }
        private bool UserGamePlaceExists(int id)
        {
            return _context.UserGamePlaces.Any(e => e.Id == id);
        }
     
    }
}
