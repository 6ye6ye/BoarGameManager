using DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameManager1.Entities
{
    public class GameRate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int Rate { get; set; }
        public Guid GameId { get; set; }
        public virtual Game Game { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
