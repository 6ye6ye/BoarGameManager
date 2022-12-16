using AutoMapper;
using BoardGameManager1.Parser.GameParser;
using BoardGamesManager.Data;
using DAL.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BoardGameManager1
{
    public class TesseraGameParser: IGameParser
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TesseraGameParser(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper= mapper;
        }

        public async Task<IEnumerable<Game>> DownloadGamesFromApi(int? count)
        {
            string baseUrl = "https://api.tesera.ru/games?offset=0&limit=1&sort=-ratingn10";
            try
            {
                //We will now define your HttpClient with your first using statement which will use a IDisposable.
                using (HttpClient client = new HttpClient())
                {
                    //In the next using statement you will initiate the Get Request, use the await keyword so it will execute the using statement in order.
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        //Then get the content from the response in the next using statement, then within it you will get the data, and convert it to a c# object.
                        using (HttpContent content = res.Content)
                        {
                            //Now assign your content to your data variable, by converting into a string using the await keyword.
                            var data = await content.ReadAsStringAsync();
                            IEnumerable<TesseraGame> tesseraGames =JsonConvert.DeserializeObject<IEnumerable<TesseraGame>> (data);
                          
                            //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
                            if (tesseraGames != null)
                            {
                                var games = _mapper.Map<IEnumerable<Game>>(tesseraGames);
                            }
                            else
                            {
                                Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }
            return null;
        }

       
    }
}
