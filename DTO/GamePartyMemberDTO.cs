namespace DTO
{

    public class GamePartyMemberDTOGetShort
    {
        public Guid Id { get; set; }
        public string PlayerName { get; set; }
        public Guid GameRoleId { get; set; }
        public int Points { get; set; }
        public bool IsWinner { get; set; }
    }
    public class GamePartyMemberDTOGet
    {
        public Guid Id { get; set; }
        public Guid GamePartyId { get; set; }
        public GameDTOGetShort Game { get; set; }
        public PlayerDTOGetShort Player { get; set; }
        public GameRoleDTOGetShort GameRole { get; set; }
        public int Points { get; set; }
        public bool IsWinner { get; set; }
    }
    public class GamePartyMemberDTOAdd
    {
        public Guid GamePartyId { get; set; }
        public Guid PlayerId { get; set; }
        public Guid GameRoleId { get; set; }
        public int Points { get; set; }
        public bool IsWinner { get; set; }
    }
    public class GamePartyMemberDTOEdit
    {
        public Guid PlayerId { get; set; }
        public Guid GameRoleId { get; set; }
        public int Points { get; set; }
        public bool IsWinner { get; set; }
    }

}
