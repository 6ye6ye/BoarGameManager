﻿namespace DTO
{
    public class GamePartyDTOGet
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public GameDTOGetShort Game { get; set; }
        public string UserGamePlaceName { get; set; }
        public string PartyCreatorName { get; set; }
    }
    //public class GamePartyDTOGet
    //{
    //    public int Id { get; set; }
    //    public DateTime Date { get; set; }
    //    public GameDTOGetShort Game { get; set; }
    //    public string UserGamePlaceName { get; set; }
    //    public string PartyCreatorName { get; set; }
    //    //public IEnumerable<GamePartyMemberDTOGetShort> GamePartyMembers { get; set; }
    //}
    public class GamePartyDTOAdd
    {
        public DateTime Date { get; set; }
        public Guid GameId { get; set; }
        public Guid? UserGamePlaceId { get; set; }

    }
    public class GamePartyDTOEdit
    {
        public DateTime Date { get; set; }
        public Guid? UserGamePlaceId { get; set; }

    }
}
