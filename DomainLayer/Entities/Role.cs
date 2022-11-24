using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameManager1.Entities
{
    public class Role : IdentityRole<Guid>
    {
        //[ForeignKey("UserId")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
