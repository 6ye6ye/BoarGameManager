namespace DTO
{
    public class GamePartyDTOGet
    {
        public Guid Id { get; set; }
        public string Date { get; set; }
        public GameDTOGetShortWithImage Game { get; set; }
        public UserGamePlaceDTOGetShort UserGamePlace{ get; set; }
        public string PartyCreatorId { get; set; }
        public string PartyCreatorName { get; set; }
    }
    public class GamePartyDTOAdd
    {
        public DateTime Date { get; set; }
        public string GameId { get; set; }
        public string? UserGamePlaceId { get; set; }

    }
    public class GamePartyDTOEdit
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string UserGamePlaceId { get; set; }
        public string GameId { get; set; }
    }
}
