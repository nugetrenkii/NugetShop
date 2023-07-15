namespace NugetShop.Models
{
    public class User
    {
        public Guid UserID { get; set; }
        public Guid UserRoleID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int Status { get; set; }

        public virtual UserRole UserRoles { get; set; }
        public virtual Cart Carts { get; set; }
        public virtual List<Bill> Bills { get; set; }
    }
}
