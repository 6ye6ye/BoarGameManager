namespace DTO
{
    public class PlayerDTOGetShort
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class PlayerDTOGet
    {
        public Guid Id { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? CreatorId { get; set; }
        public string Name { get; set; }
    }
    public class PlayerDTOAdd
    {
        public string Name { get; set; }
        public string? CreatorId { get; set; }
    }
    public class PlayerDTOEdit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}


