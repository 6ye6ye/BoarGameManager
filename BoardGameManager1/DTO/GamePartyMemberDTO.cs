using BoardGameManager1.Entities;
using DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameManager1.DTO
{
    public class GamePartyMemberDTOGet
    {
        public int Id { get; set; }
        public int GamePartyId { get; set; }
        public GameDTOGetShort Game { get; set; }
        public PlayerDTOGet Player { get; set; }
        public int GameRoleId { get; set; }
        public int Points { get; set; }
        public bool IsWinner { get; set; }
    }
    public class GamePartyMemberDTOAdd
    {
        public int GamePartyId { get; set; }
        public int PlayerId { get; set; }
        public int GameRoleId { get; set; }
        public int Points { get; set; }
        public bool IsWinner { get; set; }
    }
    public class GamePartyMemberDTOEdit
    {
        public int PlayerId { get; set; }
        public int GameRoleId { get; set; }
        public int Points { get; set; }
        public bool IsWinner { get; set; }
    }

}
