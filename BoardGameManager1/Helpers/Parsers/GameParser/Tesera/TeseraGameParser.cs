using AutoMapper;
using BoardGameManager1.Helpers.Parser.GameParser.Tesera.Models;
using BoardGameManager1.Helpers.Parser.GameParser.Tesera.Models;
using BoardGameManager1.Helpers.Parsers.GameParser.Tesera.Models;
using BoardGameManager1.Parser.GameParser;
using DAL.Entities;
using Newtonsoft.Json;

namespace BoardGameManager1.Helpers.Parser.GameParser.Tesera
{
    public class TeseraGameParser : IGameParser
    {
        private readonly IMapper _mapper;

        public TeseraGameParser(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<Game>> GetGames(int count)
        {
            var teseraGames = await GetGamesFromApi(count);
            return await ParseGames(teseraGames);
        }

        public async Task<IEnumerable<Game>> GetGamesByUserCollection(string userName)
        {
            var userId = await GetUserIdByName(userName);
            var teseraGames = await GetGamesByUserCollectionFromApi(userId);
            return await ParseGames(teseraGames);
        }

        //Tessera use allias as unique id for get requests
        public async Task<Game> GetGameById(string alias)
        {
            var teseraGame = await GetGameByAliasFromApi(alias);
            return await ParseGame(teseraGame);
        }
        private async Task<IEnumerable<TeseraGame>> GetGamesFromApi(int count)
        {
            //https://api.tesera.ru/user/SAB
            //get user games collection
            //https://tesera.ru/user/SAB/games/owns/
            //more user games by user teseraId
            //https://api.tesera.ru/collections/base/own/50489?v=1&offset=1&limit=30
            string baseUrl = $"https://api.tesera.ru/games?offset=0&limit={count}&sort=-ratingn10";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<TeseraGame>>(data);
                    }
                }
            }
        }

  


        private async Task<int> GetUserIdByName(string name)
        {
            string baseUrl = $" https://api.tesera.ru/user/{name}";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        TeseraUserGet user = JsonConvert.DeserializeObject<TeseraUserGet>(data);
                        return user.User.TeseraId;
                    }
                }
            }
        }

        private async Task<IEnumerable<TeseraGame>> GetGamesByUserCollectionFromApi(int userId)
        {
            string baseUrl = $"https://api.tesera.ru/collections/base/own/{userId}?v=1&offset=1&limit=30";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<TeseraCollectionGame>>(data).Select(c=>c.Game);
                    }
                }
            }
        }

        private async Task<TeseraGame> GetGameByAliasFromApi(string alias)
        {
            string baseUrl = $"https://api.tesera.ru/games/{alias}";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<TeseraGame>(data);
                    }
                }
            }
        }

        
        private async Task<IEnumerable<Game>> ParseGames(IEnumerable<TeseraGame> teseraGames)
        {
            return _mapper.Map<IEnumerable<Game>>(teseraGames);
        }
        private async Task<Game> ParseGame(TeseraGame teseraGame)
        {
            return _mapper.Map<Game>(teseraGame);
        }
    }
}
