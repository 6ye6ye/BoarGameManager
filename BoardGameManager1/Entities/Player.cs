using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Index(nameof(AccountId), IsUnique = true)]
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? AccountId { get; set; }
        public virtual User? Account { get; set; }

        public string? CreatorId { get; set; }
        public virtual User? Creator { get; set; }

        public virtual ICollection<GamePartyMember> GamePartiesMember { get; set; }
     }
}
