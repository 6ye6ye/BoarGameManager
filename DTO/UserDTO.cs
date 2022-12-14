namespace DTO
{
    public class UserDTOGetByName
    {
        public string UserName { get; set; }
    }

    public class UserDTOGet
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public RoleDTOGet Role { get; set; }

    }
    public class UserDTOGetShort
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }

}
