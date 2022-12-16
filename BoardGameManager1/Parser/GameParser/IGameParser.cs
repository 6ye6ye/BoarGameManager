using DAL.Entities;

namespace BoardGameManager1.Parser.GameParser
{
    public interface IGameParser
    {
        public  Task<IEnumerable<Game>> DownloadGamesFromApi(int? count);
    }
}
