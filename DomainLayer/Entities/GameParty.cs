using DomainLayer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class GameParty : BaseEntity
    {
        public DateTime Date { get; set; }
        public Guid? UserGamePlaceId { get; set; }
        public Guid? PartyCreatorId { get; set; }
        public Guid? GameId { get; set; }

        public virtual Game? Game { get; set; }
        [ForeignKey("UserGamePlaceId")]
        public virtual UserGamePlace? UserGamePlace { get; set; }
        [ForeignKey("PartyCreatorId")]
        public virtual User? PartyCreator { get; set; }
        public virtual ICollection<GamePartyMember> GamePartyMembers { get; set; }

    }
}
