using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class GameParty
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? UserGamePlaceId { get; set; }
        public string PartyCreatorId { get; set; }
        public int? GameId { get; set; }
        public virtual Game? Game { get; set; }
        [ForeignKey("UserGamePlaceId")]
        public virtual UserGamePlace? UserGamePlace { get; set; }
        [ForeignKey("PartyCreatorId")]
        public virtual User PartyCreator { get; set; }
        public virtual ICollection<GamePartyMember> GamePartyMembers { get; set; }
        //public virtual ICollection<UserWithAccount>? UserWithAccount { get; set; }
    }
}
