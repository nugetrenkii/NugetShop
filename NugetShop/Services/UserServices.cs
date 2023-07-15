using NugetShop.IServices;
using NugetShop.Models;

namespace NugetShop.Services
{
    public class UserServices : IUserServices
    {
        DataContext context;
        public UserServices()
        {
            context = new DataContext();
        }
        public bool CreateUser(User p)
        {
            try
            {
                context.User.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteUser(Guid id)
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

        public List<User> GetAllUsers()
        {
            return context.User.ToList();
        }

        public User GetUserById(Guid id)
        {
            return context.User.FirstOrDefault(p => p.UserID == id);
        }

        public List<User> GetUserByName(string name)
        {
            return context.User.Where(p => p.UserName == name).ToList();
        }

        public bool UpdateUser(User p)
        {
            try
            {
                var x = context.User.FirstOrDefault(p => p.UserID == p.UserID);
                x.UserName = p.UserName;
                x.Password = p.Password;
                x.Phone = p.Phone;
                x.UserRoles = p.UserRoles;
                x.Status = p.Status;
                context.User.Update(x);
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
