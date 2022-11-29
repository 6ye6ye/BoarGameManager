using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Index(nameof(UserId), nameof(Name), IsUnique = true)]
    public class UserGamePlace : BaseEntity
    {
        public string Name { get; set; }
        public Guid? UserId { get; set; }
      
        public virtual User User { get; set; }

        public virtual ICollection<GameParty> GameParties { get; set; }
    }
}
