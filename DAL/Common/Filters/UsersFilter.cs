namespace DAL.Common.Filters
{
    public class UsersFilter
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Guid? RoleId { get; set; }
    }
}
