namespace DTO
{
    public class GamePartyDTOGet
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public GameDTOGetShort Game { get; set; }
        public int? UserGamePlaceId { get; set; }
        public string PartyCreatorId { get; set; }
        public IEnumerable<GamePartyMemberDTOGet> GamePartyMembers { get; set; }
    }
    public class GamePartyDTOAdd
    {
        public DateTime Date { get; set; }
        public int GameId { get; set; }
        public int? UserGamePlaceId { get; set; }

    }
    public class GamePartyDTOEdit
    {
        public DateTime Date { get; set; }
        public int? UserGamePlaceId { get; set; }

    }
}
