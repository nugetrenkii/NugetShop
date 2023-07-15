namespace NugetShop.Models
{
    public class UserRole
    {
        public Guid UserRoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
