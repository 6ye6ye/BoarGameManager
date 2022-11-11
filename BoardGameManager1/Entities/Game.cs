
using BoardGameManager1.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{

    public class Game
    {
        [Key]
        public int Id {get; set;}
        public string? Image { get; set; }
        public string Name { get; set;}
        public string? NameRu { get; set; }
        public string? NameEng { get; set; }
        
        public double Rating { get; set; }
        public int RatingCount { get; set; }
        public int PlayersMinCount { get; set; }
        public int PlayersMaxCount { get; set; }
        public int MinAge {get; set; }
        public int MinPartyTime { get; set; }
        public int MaxPartyTime { get; set; }
        public int ReleaseYear { get; set; }
        public virtual ICollection<GameRate> GameRates { get; set; }
        public virtual ICollection<GameRole> GameRoles { get; set; }
        public virtual ICollection<GameParty>? GameParties { get; set; }
    }
}
