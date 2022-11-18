using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;
using BoardGamesManager.Data;
using DAL;
using DTO;
using Microsoft.EntityFrameworkCore;
namespace BoardUserFriendManager1.Services
{
    public class UserFriendService
    {
      
        
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public UserFriendService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get added friends
        public async Task<IEnumerable<UserFriendDTOGet>> GetUserFriendsByUserId(string userId)
        {
            //TODO
            //Не получать информацию о себе
            var userFriends = await _context.UserFriends
                .Where(u=>(u.InRequestUserId==userId|| u.OutRequestUserId==userId) && u.Status==FriendStatus.Added)
                .Select(c=>new UserFriendDTOGet() { Id=c.Id,Friend=c.InRequestUserId==userId? _mapper.Map<UserDTOGetShort>(c.OutRequestUser): _mapper.Map<UserDTOGetShort> (c.InRequestUser)})
                .ToListAsync();

            return userFriends;
           // return _mapper.Map<IEnumerable<UserFriendDTOGet>>(userFriends);
        }


        //Get input request to add to friends
        public async Task<IEnumerable<UserFriendDTOGet>> GetUserFriendIncomingRequests(string userId)
        {

            var userFriends = await _context.UserFriends
                .Where(u => u.InRequestUserId == userId  && u.Status == FriendStatus.Request)
                .Select(c => new UserFriendDTOGet() { Friend =_mapper.Map<UserDTOGetShort>(c.OutRequestUser) })
                .ToListAsync();

            return userFriends;
            // return _mapper.Map<IEnumerable<UserFriendDTOGet>>(userFriends);
        }

        //Get out request to add to friends (now not confirmed)
        public async Task<IEnumerable<UserFriendDTOGet>> GetUserFriendOutRequests(string userId)
        {

            var userFriends = await _context.UserFriends
                .Where(u => u.OutRequestUserId == userId && u.Status == FriendStatus.Request)
                .Select(c => new UserFriendDTOGet() { Friend = _mapper.Map<UserDTOGetShort>(c.InRequestUser) })
                .ToListAsync();
            return userFriends;
            // return _mapper.Map<IEnumerable<UserFriendDTOGet>>(userFriends);
        }

        public async Task<UserFriendDTOGet> GetUserFriendById(int id)
        {
            var userFriend = await getUserById(id);
            return _mapper.Map<UserFriendDTOGet>(userFriend);
        }


        public async Task<int> AddUserFriend(UserFriendDTOAdd userFriendDTO)
        {
            var userFriend = _mapper.Map<UserFriend>(userFriendDTO);
            _context.UserFriends.Add(userFriend);
            await _context.SaveChangesAsync();
            return userFriend.Id;
        }

        //public async Task<UserFriendDTOEdit> EditUserFriend(UserFriendDTOEdit userFriendDTO)
        //{
        //    var userFriend = _mapper.Map<UserFriend>(userFriendDTO);
        //    _context.UserFriends.Attach(userFriend);

        //    _context.Entry(userFriend).Property(a => a.Image).IsModified = true;
        //    _context.Entry(userFriend).Property(a => a.PlayersMinCount).IsModified = true;
        //    _context.Entry(userFriend).Property(a => a.PlayersMaxCount).IsModified = true;

        //    userFriend.ModifiedOn = DateTime.Now;
        //    account.ModifiedBy = 1;

        //    _context.SaveChanges();
        //}

        public async Task DeleteUserFriend(int id)
        {
            var userFriend = await getUserById(id);
            _context.UserFriends.Remove(userFriend);
            await _context.SaveChangesAsync();
        }
        public async Task Rate(UserFriend userFriend, int rate)
        {
            //TODO rating
            //var newRate = 0;
            //if (rate > userFriend.Rating)
            //{
            //    newRate=userFriend. userFriend.Rating
            //}

            _context.UserFriends.Update(userFriend);
            await _context.SaveChangesAsync();
        }
        private async Task<UserFriend> getUserById(int id)
        {
            var userFriend = await _context.UserFriends.FindAsync(id);
            if (userFriend == null)
                throw new NotFoundException("User");
            return userFriend;
        }

    }
}
