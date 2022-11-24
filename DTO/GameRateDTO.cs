namespace DTO
{
    public class GameRateDTOGet
    {
        public Guid Id { get; set; }
        public int Rate { get; set; }
        public GameDTOGetShort Game { get; set; }
        public virtual UserDTOGetShort User { get; set; }
    }
    public class GameRateDTOPost
    {
        public Guid GameId { get; set; }
        public int Rate { get; set; }
    }
}
