using BoardGameManager1.Entities;
using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Game: BaseEntity
    {
        public string? Image { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string? NameRu { get; set; }
        public string? NameEng { get; set; }
        public string? GameInfoShort { get; set; }
        public string? GameInfo { get; set; }
        public double Rating { get; set; }
        public int RatingCount { get; set; }
        public int PlayersMinCount { get; set; }
        public int PlayersMaxCount { get; set; }
        public int MinAge { get; set; }
        public int MinPartyTime { get; set; }
        public int MaxPartyTime { get; set; }
        public int ReleaseYear { get; set; }
        public DateTime DateAdded { get; set; }

        public int? TeseraId { get; set; }

        public virtual ICollection<GameRate> GameRates { get; set; }
        public virtual ICollection<GameRole> GameRoles { get; set; }
        public virtual ICollection<GameParty>? GameParties { get; set; }
        public virtual ICollection<UserGame>? UserGames { get; set; }
    }
}
