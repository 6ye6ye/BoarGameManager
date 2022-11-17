namespace DTO
{
    public class UserGamePlaceDTOGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
    }

    public class UserGamePlaceDTOGetShort
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UserGamePlaceDTOAdd
    {
        public string Name { get; set; }
    }
    //public class UserGamePlaceDTOEdit
    //{
    //    public string Name { get; set; }
    //}
}
