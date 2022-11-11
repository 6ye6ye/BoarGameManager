using AutoMapper;
using BoardGameManager1;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.DTO;
using BoardGamesManager.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<PlayerDTOGet>> GetPlayers()
        {
            var players = await _context.Players.ToListAsync();
            return _mapper.Map<List<PlayerDTOGet>>(players).AsEnumerable();
        }

        public async Task<PlayerDTOGet> GetPlayerById(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
                throw new NotFoundException("Player not found");
            return _mapper.Map<PlayerDTOGet>(player);
        }

        public async Task AddPlayer(User user)
        {
            var player = new Player() { AccountId = user.Id, Name = user.UserName };
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

        }
    }
}
