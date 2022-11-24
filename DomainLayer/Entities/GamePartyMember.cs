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

        [ForeignKey("GamePartyId")]
        public virtual GameParty GameParty { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }

        [ForeignKey("GameRoleId")]
        public virtual GameRole GameRole { get; set; }
    }
}


//using System.Text;
//using System.Threading.Tasks;

//namespace DAL.Entities
//{
//    public class GamePartyMember
//    {
//        public int Id { get; set; }
//        public int GamePartyId { get; set; }
//        public int? MemberWithAccountId { get; set; }
//        public int? MemberWithoutAccountId { get; set; }
//        public int GameRoleId { get; set; }
//        public int Points { get; set; }
//        public bool IsWinner { get; set; }

//        [ForeignKey("GamePartyId")]
//        public virtual GameParty GameParty { get; set; }

//        [ForeignKey("MemberWithAccountId")]
//        public virtual User? MemberWithAccount { get; set; }
//        [ForeignKey("UserWithoutAccountId")]
//        public virtual Players? MemberWithoutAccount { get; set; }
//        // public virtual GameParty? GameParty { get; set; }

//    }
//}