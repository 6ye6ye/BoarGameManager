using Microsoft.AspNetCore.Identity;

namespace BoardGameManager1.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
