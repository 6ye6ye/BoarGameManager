using BoardGameManager1.Enums;

namespace DTO
{
    public class UserFriendDTOGetByName
    {
        public string UserName { get; set; }
        // public string Status { get; set; }
    }
    public class UserFriendDTOGet
    {
        public Guid Id { get; set; }
        public UserDTOGetShort Friend { get; set; }
       // public string Status { get; set; }
    }
    public class UserFriendDTOGetWihhDetails
    {
        public Guid Id { get; set; }
        public UserDTOGet Friend { get; set; }
       // public FriendStatus Status { get; set; }
    }
    public class UserFriendDTOAdd
    {
        public Guid OutRequestUser { get; set; }
    }
    public class UserFriendDTOEdit
    {
        public FriendStatus Status { get; set; }
    }
}
