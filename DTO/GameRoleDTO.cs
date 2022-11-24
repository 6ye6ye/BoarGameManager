namespace DTO
{

    public class GameRoleDTOGetShort
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
    public class GameRoleDTOGet
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public string Name { get; set; }

    }
    public class GameRoleDTOAdd
    {
        public string GameId { get; set; }
        public string Name { get; set; }
    }

    public class GameRoleDTOEdit
    {
        public string Name { get; set; }
    }

}
