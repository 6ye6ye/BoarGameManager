using BoardGameManager1.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class GamePartyMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid GamePartyId { get; set; }
        public Guid PlayerId { get; set; }
        public Guid GameRoleId { get; set; }
        public int Points { get; set; }
        public bool IsWinner { get; set; }

        public virtual GameParty GameParty { get; set; }
        public virtual Player Player { get; set; }
        public virtual GameRole GameRole { get; set; }
    }
}
