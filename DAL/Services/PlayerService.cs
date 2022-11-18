﻿using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Enums;
using BoardGamesManager.Data;
using BoardUserFriendManager1.Services;
using DAL.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BoardPlayerManager1.Services
{
    public class PlayerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public PlayerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerDTOGet>> GetPlayersForCurrentUser(string userId)
        {
            var userFriendsId = await _context.UserFriends
                .Where(u => (u.InRequestUserId == userId || u.OutRequestUserId == userId) && u.Status == FriendStatus.Added)
                .Select(c => c.InRequestUserId == userId ? c.OutRequestUser.Id : c.InRequestUser.Id )
                .ToListAsync();
            var players = await _context.Players
                 
                .Where(p=>p.AccountId==userId||p.CreatorId==userId|| userFriendsId.Contains(p.AccountId))
                .Select(p=> _mapper.Map<PlayerDTOGet>(p))
                .ToListAsync();

            return players.AsEnumerable();
        }

        public async Task<PlayerDTOGet> GetPlayerById(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
                throw new NotFoundException("Player");
            return _mapper.Map<PlayerDTOGet>(player);
        }

        public async Task<int> AddPlayerToCurrentUser(PlayerDTOAdd playerDto)
        {
            var player = new Player() { CreatorId = playerDto.CreatorId, Name = playerDto.Name };
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player.Id;
        }

        public async Task DeletePlayer(int id)
        {
            var player = _context.Players.Find(id);
            if (player == null)
                throw new NotFoundException("player");
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }
        public async Task AddPlayer(User user)
        {
            var player = new Player() { AccountId = user.Id, Name = user.UserName };
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

        }
    }
}
