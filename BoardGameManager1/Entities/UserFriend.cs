using BoardGameManager1.Enums;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Index(nameof(InRequestUserId), nameof(OutRequestUserId), IsUnique = true)]
    public  class UserFriend
    {
        public int Id { get; set; }
       
        public string? InRequestUserId { get; set; }
        public virtual User? InRequestUser { get; set; }
     
        public string? OutRequestUserId { get; set; }
        public virtual User? OutRequestUser { get; set; }

        [DefaultValue(FriendStatus.Request)]
        public FriendStatus Status { get; set; }

    }
}
//     [ForeignKey("InRequestUserId")]

//   [InverseProperty("AcceptedFriends")]

//   [ForeignKey("OutRequestUserId")]
//    [InverseProperty("AddedFriends")]