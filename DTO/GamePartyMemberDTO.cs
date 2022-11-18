namespace DTO
{

    public class GamePartyMemberDTOGetShort
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int GameRoleId { get; set; }
        public int Points { get; set; }
        public bool IsWinner { get; set; }
    }
    public class GamePartyMemberDTOGet
    {
        public int Id { get; set; }
        public int GamePartyId { get; set; }
        public GameDTOGetShort Game { get; set; }
        public PlayerDTOGetShort Player { get; set; }
        public GameRoleDTOGetShort GameRole { get; set; }
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
