using BoardGameManager1.Entities;
using BoardGameManager1.Enums;
using Microsoft.AspNetCore.Authorization;

namespace BoardGameManager1
{
    public class AppAutorizeAttribute:AuthorizeAttribute
    {
        public AppAutorizeAttribute(params UserRoleEnum[] roles):base()
        { 
            Roles = string.Join(",", roles.Select(r => r));
        }
    }
}
