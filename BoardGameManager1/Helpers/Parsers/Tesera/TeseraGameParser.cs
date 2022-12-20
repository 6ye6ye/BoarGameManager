using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using BoardGameManager1.Helpers.Parser.GameParser.Tesera.Models;
using BoardGameManager1.Helpers.Parsers;
using BoardGameManager1.Helpers.Parsers.GameParser.Tesera;
using BoardGameManager1.Helpers.Parsers.GameParser.Tesera.Models;
using DAL.Common.Exceptions;
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
       
        public async Task<IEnumerable<Game>> GetLastAddedGames(int count)
        {
            var teseraGames = await GetDataFromUrl<List<TeseraGame>>(TesseraUrlHelper.GetGamesLastAddedUrl(count));
            return await ParseGames(teseraGames);
        }

        public async Task<IEnumerable<Game>> GetTopGamesByRate(int count)
        {
            var teseraGames = await GetDataFromUrl<List<TeseraGame>>(TesseraUrlHelper.GetGamesUrl(count, "&sort=-ratingn10"));
            return await ParseGames(teseraGames);
        }

        public async Task<IEnumerable<Game>> GetGamesByUserCollection(string userName,int count)
        {
            var user = await GetDataFromUrl<TeseraUserGet>(TesseraUrlHelper.GetUserByNameUrl(userName)); 
            var teseraGames = await GetDataFromUrl<List<TeseraCollectionGame>>(TesseraUrlHelper.GetGamesByUserCollectionUrl(user.user.teseraId, count));
            return await ParseGames(teseraGames.Select(c=>c.Game));
        }

        //Tessera use allias as unique id for get requests
        public async Task<Game> GetGameById(string alias)
        {
            var url = TesseraUrlHelper.GetGameByAlias(alias);
            var teseraGame = await GetDataFromUrl<TeseraGame>(url);
            if (teseraGame.alias == null)
                throw new NotFoundException(alias);
            return await ParseGame(teseraGame);
        }


        private async Task<TEntity> GetDataFromUrl<TEntity>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url))
                {
                    using (HttpContent content = res.Content)
                    {
                        var result= await content.ReadAsStringAsync();//<TEntity>
                        var data= JsonConvert.DeserializeObject<TEntity>(result);
                        if (result == null)
                            throw new NotFoundExternalApiException(url, nameof(TEntity));
                        return data ;
         
                    }
                }
            }
        }

        private async Task<IEnumerable<Game>> ParseGames(IEnumerable<TeseraGame> teseraGames)
        {
            return _mapper.Map<List<Game>>(teseraGames);
        }
        private async Task<Game> ParseGame(TeseraGame teseraGame)
        {
            return _mapper.Map<Game>(teseraGame);
        }
    }
}
