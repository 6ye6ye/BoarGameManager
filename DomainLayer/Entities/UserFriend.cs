using BoardGameManager1.Enums;
using DAL.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class UserFriend
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
