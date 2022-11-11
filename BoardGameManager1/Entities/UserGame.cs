using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Entities
{
    [Index(nameof(UserId), nameof(GameId), IsUnique = true)]
    public class UserGame
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GameId { get; set; }
       // [ForeignKey("UserId")]
        public virtual User User { get; set; }
        //[ForeignKey("GameId")]
        public virtual Game Game { get; set; }
    }
}
