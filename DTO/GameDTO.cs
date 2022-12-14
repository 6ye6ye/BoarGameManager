namespace DTO
{
    public class GameDTOGet
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string NameRu { get; set; }
        public string NameEng { get; set; }
        public double Rating { get; set; }
        public int RatingCount { get; set; }
        public int PlayersMinCount { get; set; }
        public int PlayersMaxCount { get; set; }
        public int MinAge { get; set; }
        public string GameInfoShort { get; set; }
        public string? GameInfo { get; set; }
        public int MinPartyTime { get; set; }
        public int MaxPartyTime { get; set; }
        public int ReleaseYear { get; set; }

        public bool AddedToUserGames { get; set; }
    }
    public class GameDTOGetShort: IGameDTOGetShort
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public interface IGameDTOGetShort
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class GameDTOGetShortWithImage: IGameDTOGetShort
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
    public class GameDTOAdd
    {
        public string? Image { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string NameRu { get; set; }
        public string NameEng { get; set; }
        public string GameInfoShort { get; set; }
        public string? GameInfo { get; set; }
        public int PlayersMinCount { get; set; }
        public int PlayersMaxCount { get; set; }
        public int MinAge { get; set; }
        public int MinPartyTime { get; set; }
        public int MaxPartyTime { get; set; }
        public int ReleaseYear { get; set; }
        public int? TesseraId { get; set; }
    }
    public class GameDTOEdit
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string NameRu { get; set; }
        public string NameEng { get; set; }
        public string GameInfoShort { get; set; }
        public string GameInfo { get; set; }
        public int PlayersMinCount { get; set; }
        public int PlayersMaxCount { get; set; }
        public int MinAge { get; set; }
        public int MinPartyTime { get; set; }
        public int MaxPartyTime { get; set; }
        public int ReleaseYear { get; set; }
        public int? TesseraId { get; set; }
    }
}
