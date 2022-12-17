using DAL.Entities;
using DTO;

namespace BoardGameManager1.Parser.GameParser
{
    public interface IGameParser
    {
        public Task<Game> GetGameById(string id);
        public  Task<IEnumerable<Game>> GetGames(int count);
        public Task<IEnumerable<Game>> GetGamesByUserCollection(string name);
    }
}
