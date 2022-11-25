using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BoardGameManager1.Entities
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
