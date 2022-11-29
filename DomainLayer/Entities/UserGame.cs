using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Index(nameof(UserId), nameof(GameId), IsUnique = true)]
    public class UserGame : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }


        public virtual User User { get; set; }

        public virtual Game Game { get; set; }
    }
}
