using DAL.Entities;
using DomainLayer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameManager1.Entities
{
    public class GameRate : BaseEntity
    {
         public int Rate { get; set; }
        public Guid GameId { get; set; }
        public virtual Game Game { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
