using NugetShop.Models;

namespace NugetShop.IServices
{
    public interface IUserRoleServices
    {
        public bool CreateUserRole(UserRole p);
        public bool DeleteUserRole(Guid id);
        public bool UpdateUserRole(UserRole p);

        public List<UserRole> GetAllUserRole();
        public UserRole GetUserRoleById(Guid id);
        public List<UserRole> GetUserRoleByName(string name);

    }
}
