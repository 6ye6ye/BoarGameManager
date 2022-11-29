using DomainLayer;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Player : BaseEntity
    {
     
        public string Name { get; set; }

        public Guid? AccountId { get; set; }
        public virtual User? Account { get; set; }

        public Guid? CreatorId { get; set; }
        public virtual User? Creator { get; set; }

        public virtual ICollection<GamePartyMember> GamePartiesMember { get; set; }
    }
}
