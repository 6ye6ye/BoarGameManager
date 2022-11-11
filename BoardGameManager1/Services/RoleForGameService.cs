//using AutoMapper;
//using BoardGameManager1.DTO;
//using BoardGamesManager.Data;
//using DAL.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace BoardGameManager1.Services
//{
//    public class RoleForGameService
//    {
//        private readonly AppDbContext _context;
//        private readonly IMapper _mapper;


//        public RoleForGameService(AppDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        public async Task<IEnumerable<RoleForGameDTOGet>> GetRolesForGames()
//        {
//            var users = await _context.RolesForGame.ToListAsync();
//            return _mapper.Map<List<RoleForGameDTOGet>>(users).AsEnumerable();
//        }

//        public async Task<RoleForGameDTOGet> GetRolesForGameById(int  id)
//        {
//            var user = await _context.RolesForGame
//                .FirstOrDefaultAsync(u => u.Id == id);
//            //var user = await _context.Users.FindAsync(id);

//            return _mapper.Map<RoleForGameDTOGet>(user);
//        }
//        public async Task<int> AddRoleForGame(RoleForGameDTOAdd roleForGameDTO)
//        {
//            var roleForGame = _mapper.Map<RoleForGame>(roleForGameDTO);

//            _context.RolesForGame.Add(roleForGame);
//            await _context.SaveChangesAsync();
//            return roleForGame.Id;
//        }
//        public async Task DeleteGame(RoleForGame roleForGame)
//        {
//            _context.RolesForGame.Remove(roleForGame);
//            await _context.SaveChangesAsync();
//        }
//    }
//}
