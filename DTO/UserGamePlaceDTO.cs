namespace DTO
{
    public class UserGamePlaceDTOGet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }

    public class UserGamePlaceDTOGetShort
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class UserGamePlaceDTOAdd
    {
        public string Name { get; set; }
    }

    public class UserGamePlaceDTOEdit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
