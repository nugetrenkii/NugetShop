using Microsoft.EntityFrameworkCore;
using NugetShop.IServices;
using NugetShop.Models;

namespace NugetShop.Services
{
    public class CartDetailServices : ICartDetailServices
    {
        DataContext context;
        public CartDetailServices()
        {
            context = new DataContext();
        }
        public bool CreateCartDetail(CartDetail p)
        {
            try
            {
                context.CartDetails.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCartDetail(Guid id)
        {
            try
            {
                var cartdetail = context.CartDetails.FirstOrDefault(p => p.CartDetailID == id);
                if (cartdetail != null)
                {
                    context.CartDetails.Remove(cartdetail);
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<CartDetail> GetAllCartDetails()
        {
            return context.CartDetails.Include(cd => cd.Products).ThenInclude(p => p.Colors)
                 .Include(cd => cd.Products).ThenInclude(p => p.Size)
                 .Include(cd => cd.Products).ThenInclude(p => p.Image)
                 .ToList();
        }
        public CartDetail GetCartDetailById(Guid id)
        {
            return context.CartDetails.FirstOrDefault(p => p.CartDetailID == id);
        }
        public List<CartDetail> GetCartDetailByName(string name)
        {
            throw new NotImplementedException();
        }
        public bool UpdateCartDetail(CartDetail p)
        {
            try
            {
                var x = context.CartDetails.Find(p.CartDetailID);
                x.UserID = p.UserID;
                x.ProductID = p.ProductID;
                x.Quantity = p.Quantity;
                x.Price = p.Price;
                x.Status = p.Status;
                context.CartDetails.Update(x);
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
