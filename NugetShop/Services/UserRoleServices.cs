using NugetShop.IServices;
using NugetShop.Models;

namespace NugetShop.Services
{
    public class UserRoleServices : IUserRoleServices
    {
        DataContext context;

        public UserRoleServices()
        {
            context = new DataContext();
        }

        public bool CreateUserRole(UserRole p)
        {
            try
            {
                context.UserRole.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteUserRole(Guid id)
        {
            try
            {
                var product = context.User.Find(id);
                context.User.Remove(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<UserRole> GetAllUserRole()
        {
            return context.UserRole.ToList();
        }

        public UserRole GetUserRoleById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<UserRole> GetUserRoleByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserRole(UserRole p)
        {
            try
            {
                var product = context.UserRole.Find(p.UserRoleID);
                product.RoleName = p.RoleName;
                product.Description = p.Description;
                context.UserRole.Update(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



    }
}
