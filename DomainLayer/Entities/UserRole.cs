using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameManager1.Entities
{
    public class UserRole : IdentityUserRole<Guid>
    {
       // public override string UserId { get; set; }
        //[ForeignKey("UserId")]
        public virtual User User { get; set; }
        
        ////public override string RoleId { get; set; }
        //[ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
