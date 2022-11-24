using BoardGameManager1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common.Filters
{
    public class UsersFilter
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Guid? RoleId { get; set; }
    }
}
