using DAL.Entities;
using DomainLayer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameManager1.Entities
{
    public class GameRole : BaseEntity
    {
        public Guid GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GamePartyMember> GamePartyMembers { get; set; }
    }
}
