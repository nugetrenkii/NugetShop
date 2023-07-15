using NugetShop.Models;

namespace NugetShop.IServices
{
    public interface ICartServices
    {
        public bool CreateCart(Cart p);
        public bool DeleteCart(Guid id);
        public bool UpdateCart(Cart p);

        public List<Cart> GetAllCarts();
        public Cart GetCartById(Guid id);
        public List<Cart> GetCartByName(string name);

    }
}
