using BoardGameManager1.Entities;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{

    public class User :IdentityUser<Guid>
    {
        public string? RoleId { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<Player>? CreatedPlayers { get; set; }
        public virtual ICollection<Player>? PlayGamesPlayers { get; set; }

        public virtual ICollection<UserFriend>? AddedFriends { get; set; }
        public virtual ICollection<UserFriend>? AcceptedFriends { get; set; }

        public virtual ICollection<UserGame> Games { get; set; }

        public virtual ICollection<GameParty> CreatedGames { get; set; }

        public virtual ICollection<Role> Roles { get; set; }




        //   [InverseProperty("Creator")]
        //  [InverseProperty("Account")]
        //  [InverseProperty("OutRequestUser")]
        //   [InverseProperty("InRequestUser")]
        //public virtual ICollection<FriendRequest> InputRequests { get; set; }
        // public virtual ICollection<FriendRequest> OutputRequests { get; set; }
    }
}
