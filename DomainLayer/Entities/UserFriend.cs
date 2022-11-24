using BoardGameManager1.Enums;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  //  [Index(nameof(InRequestUserId), nameof(OutRequestUserId), IsUnique = true)]
    public  class UserFriend
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid? InRequestUserId { get; set; }
        public virtual User InRequestUser { get; set; }

        public Guid? OutRequestUserId { get; set; }
        public virtual User OutRequestUser { get; set; }

        [DefaultValue(FriendStatus.Request)]
        public FriendStatus Status { get; set; }

    }
}
//     [ForeignKey("InRequestUserId")]

//   [InverseProperty("AcceptedFriends")]

//   [ForeignKey("OutRequestUserId")]
//    [InverseProperty("AddedFriends")]