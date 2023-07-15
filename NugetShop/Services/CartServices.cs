using Microsoft.EntityFrameworkCore;
using NugetShop.IServices;
using NugetShop.Models;

namespace NugetShop.Services
{
    public class CartServices : ICartServices
    {
        DataContext context;

        public CartServices()
        {
            context = new DataContext();
        }
        public bool CreateCart(Cart p)
        {
            try
            {
                context.Carts.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCart(Guid id)
        {
            try
            {
                var product = context.Carts.Find(id);
                context.Carts.Remove(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Cart> GetAllCarts()
        {
            return context.Carts.Include("User").ToList();
        }

        public Cart GetCartById(Guid id)
        {
            return context.Carts.FirstOrDefault(p => p.CartID == id);
        }

        public List<Cart> GetCartByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCart(Cart p)
        {
            try
            {
                var product = context.Carts.Find(p.CartID);
                product.Description = p.Description;
                context.Carts.Update(product);
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
