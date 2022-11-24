using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class GameParty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid? UserGamePlaceId { get; set; }
        public Guid PartyCreatorId { get; set; }
        public Guid? GameId { get; set; }
        public virtual Game? Game { get; set; }
        [ForeignKey("UserGamePlaceId")]
        public virtual UserGamePlace? UserGamePlace { get; set; }
        [ForeignKey("PartyCreatorId")]
        public virtual User PartyCreator { get; set; }
        public virtual ICollection<GamePartyMember> GamePartyMembers { get; set; }

    }
}
