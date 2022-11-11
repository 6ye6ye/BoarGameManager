//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DAL.Entities
//{
//    public class FriendRequest
//    {
//        public int Id { get; set; }

//        public int CurrentUserId { get; set; }
//        public int RequestUserId { get; set; }

//        [ForeignKey("CurrentUserId")]
//        public virtual User CurrentUser { get; set; }
//        [ForeignKey("RequestUserId")]
//        public virtual User RequestUser { get; set; }
//        //public virtual UserWithAccount? CurrentUser { get; set; }
//        //public virtual UserWithAccount? RequestUser { get; set; }
//    }
//}
