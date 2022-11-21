using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace DTO
{
    public class GameDTOGet
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string NameRu { get; set; }
        public string NameEng { get; set; }
        public double Rating { get; set; }
        public int RatingCount { get; set; }
        public int PlayersMinCount { get; set; }
        public int PlayersMaxCount { get; set; }
        public int MinAge { get; set; }
        public int MinPartyTime { get; set; }
        public int MaxPartyTime { get; set; }
        public int ReleaseYear { get; set; }
        public bool AddedToUserGames { get; set; }
    }
    public class GameDTOGetShort
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class GameDTOAdd
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string NameRu { get; set; }
        public string NameEng { get; set; }
        
        
        //public float Rating { get; set; }
        // public int VotesCount { get; set; }
        public int PlayersMinCount { get; set; }
        public int PlayersMaxCount { get; set; }
        public int MinAge { get; set; }
        public int MinPartyTime { get; set; }
        public int MaxPartyTime { get; set; }
        public int ReleaseYear { get; set; }
    }
    public class GameDTOEdit
    {
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? NameRu { get; set; }
        public string? NameEng { get; set; }
        public int? PlayersMinCount { get; set; }
        public int? PlayersMaxCount { get; set; }
        public int? MinAge { get; set; }
        public int? MinPartyTime { get; set; }
        public int? MaxPartyTime { get; set; }
        public int? ReleaseYear { get; set; }
    }
}
