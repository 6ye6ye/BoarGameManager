using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
  //  [Index(nameof(AccountId), IsUnique = true)]
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid? AccountId { get; set; }
        public virtual User? Account { get; set; }

        public Guid? CreatorId { get; set; }
        public virtual User? Creator { get; set; }

        public virtual ICollection<GamePartyMember> GamePartiesMember { get; set; }
    }
}
