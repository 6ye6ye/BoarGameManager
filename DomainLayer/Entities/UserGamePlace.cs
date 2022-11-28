using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Index(nameof(UserId), nameof(Name), IsUnique = true)]
    public class UserGamePlace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? UserId { get; set; }
      
        public virtual User User { get; set; }

        public virtual ICollection<GameParty> GameParties { get; set; }
    }
}
