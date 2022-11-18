namespace DTO
{
    public class PlayerDTOGetShort
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class PlayerDTOGet
    {
        public int Id { get; set; }
        public string? AccountId { get; set; }
        public string? CreatorId { get; set; }
        public string Name { get; set; }
    }
    public class PlayerDTOAdd
    {
        public string Name { get; set; }
        public string? CreatorId { get; set; }
    }

}


