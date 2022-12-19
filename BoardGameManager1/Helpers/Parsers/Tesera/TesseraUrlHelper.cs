using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameManager1.Helpers.Parsers.GameParser.Tesera
{

    public static class TesseraUrlHelper 
    {
        public static string GetGamesUrl(int count, string sortParams)
        {
            return $"https://api.tesera.ru/games?offset=0&limit={count}&{sortParams}";
        }
        public static string GetGamesByUserCollectionUrl( int userId, int count)
        {
            return $"https://api.tesera.ru/collections/base/own/{userId}?v=1&offset=1&limit={count}";
        }
        public static string GetGamesLastAddedUrl(int count)
        {
            return $"https://api.tesera.ru/games?offset=0&limit={count}&sort=-creationdateutc";
        }
        public static string GetUserByNameUrl(string name)
        {
            return $" https://api.tesera.ru/user/{name}";
        }
        public static string GetGameByAlias(string alias)
        {
            return $"https://api.tesera.ru/games/{alias}";
        }

    }
}
