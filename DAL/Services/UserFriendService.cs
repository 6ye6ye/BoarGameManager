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
        public async Task<IEnumerable<UserFriendDTOGet>> GetUserFriendsByUserId(Guid userId)
        {
            var userFriends = await _context.UserFriends
                .Where(u => (u.InRequestUserId == userId || u.OutRequestUserId == userId) && u.Status == FriendStatus.Added)
                .Select(c => new UserFriendDTOGet() { Id = c.Id, Friend = c.InRequestUserId == userId ? _mapper.Map<UserDTOGetShort>(c.OutRequestUser) : _mapper.Map<UserDTOGetShort>(c.InRequestUser) })
                .ToListAsync();
            return userFriends;
        }

        //Get input request to add to friends
        public async Task<IEnumerable<UserFriendDTOGet>> GetUserFriendIncomingRequests(Guid userId)
        {
            var userFriends = await _context.UserFriends
               .Where(u => u.OutRequestUserId == userId && u.Status == FriendStatus.Request)
               .Include(c => c.InRequestUser)
               .Select(c => new UserFriendDTOGet() { Id = c.Id, Friend = _mapper.Map<UserDTOGetShort>(c.InRequestUser) })
               .ToListAsync();
            return userFriends;
        }

        //Get out request to add to friends (now not confirmed)
        public async Task<IEnumerable<UserFriendDTOGet>> GetUserFriendOutRequests(Guid userId)
        {
            var userFriends = await _context.UserFriends
                .Where(u => u.InRequestUserId == userId && u.Status == FriendStatus.Request)
                .Include(c => c.OutRequestUser)
                .Select(c => new UserFriendDTOGet() { Id = c.Id, Friend = _mapper.Map<UserDTOGetShort>(c.OutRequestUser) })
                .ToListAsync();
            return userFriends;
        }

        public async Task<UserFriendDTOGet> GetUserFriendById(string id)
        {
            var userFriend = await getUserById(id);
            return _mapper.Map<UserFriendDTOGet>(userFriend);
        }

        public async Task<Guid> AddUserFriend(Guid userId, Guid outRequestUserId)
        {
            var userFriend = await _context.UserFriends.FirstOrDefaultAsync(c => c.InRequestUserId == outRequestUserId && c.OutRequestUserId == userId);
            if (userFriend != null)
                throw new DoublicateException("Сan't send request");
            userFriend = new UserFriend()
            {
                InRequestUserId = userId,
                OutRequestUserId = outRequestUserId,
                Status = FriendStatus.Request
            };
            _context.UserFriends.Add(userFriend);
            await _context.SaveChangesAsync();
            return userFriend.Id;
        }

        public async Task IgnoreUserFriend(string id)
        {
            var userFriend = await _context.UserFriends.FindAsync(new Guid(id));
            if (userFriend == null)
                throw new NotFoundException("Request");
            userFriend.Status = FriendStatus.Rejected;
            _context.Entry(userFriend).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task AcceptUserFriend(string id)
        {
            var userFriend = await _context.UserFriends.FindAsync(new Guid(id));
            if (userFriend == null)
                throw new NotFoundException("Request");
            userFriend.Status = FriendStatus.Added;
            _context.Entry(userFriend).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserFriend(string id)
        {
            var userFriend = await getUserById(id);
            _context.UserFriends.Remove(userFriend);
            await _context.SaveChangesAsync();
        }

        private async Task<UserFriend> getUserById(string id)
        {
            var userFriend = await _context.UserFriends.FindAsync(new Guid(id));
            if (userFriend == null)
                throw new NotFoundException("User");
            return userFriend;
        }

    }
}
