using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Index(nameof(UserId), nameof(Name), IsUnique = true)]
    public class UserGamePlace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
