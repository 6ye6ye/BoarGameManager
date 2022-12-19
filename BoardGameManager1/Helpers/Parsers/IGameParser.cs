using DAL.Entities;
using DTO;

namespace BoardGameManager1.Helpers.Parsers
{
    public interface IGameParser
    {
        public Task<Game> GetGameById(string id);
        public Task<IEnumerable<Game>> GetTopGamesByRate(int count);
        public Task<IEnumerable<Game>> GetLastAddedGames(int count);
        public Task<IEnumerable<Game>> GetGamesByUserCollection(string name, int count);
    }
}
