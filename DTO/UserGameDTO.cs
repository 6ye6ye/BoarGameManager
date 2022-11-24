namespace DTO
{
    public class UserGameDTOGet
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }

    }
    public class UserGameDTOAdd
    {
        public int GameId { get; set; }
    }
}
