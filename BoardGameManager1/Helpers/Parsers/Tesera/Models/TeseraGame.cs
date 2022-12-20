using Microsoft.AspNetCore.Mvc;

namespace BoardGameManager1.Helpers.Parser.GameParser.Tesera.Models
{
    public class TeseraGameGet
    {
        public TeseraGame game { get; set; }
    }
    public class TeseraGame
    {
        public int teseraId { get; set; }
        //public int bggId { get; set; }
        public string title { get; set; }
        public string title2 { get; set; }
        public string title3 { get; set; }
        public string alias { get; set; }
        public string descriptionShort { get; set; }
        public string description { get; set; }
        //public string modificationDateUtc { get; set; }
        public string creationDateUtc { get; set; }
        public string photoUrl { get; set; }
        public int year { get; set; }
        //public double ratingUser { get; set; }
        //public double n10Rating { get; set; }
        //public double n20Rating { get; set; }
        //public double bggRating { get; set; }
        //public double bggGeekRating { get; set; }
        //public int bggNumVotes { get; set; }
        //public int numVotes { get; set; }
        public int playersMin { get; set; }
        public int playersMax { get; set; }
        public int playersMinRecommend { get; set; }
        public int playersMaxRecommend { get; set; }
        public int playersAgeMin { get; set; }
        //public int timeToLearn { get; set; }
        public int playtimeMin { get; set; }
        public int playtimeMax { get; set; }
        //public int commentsTotal { get; set; }
        //public int commentsTotalNew { get; set; }
        public bool isAddition { get; set; }
    }
}
