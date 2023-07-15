using NugetShop.Models;

namespace NugetShop.IServices
{
    public interface ICartDetailServices
    {
        public bool CreateCartDetail(CartDetail p);
        public bool DeleteCartDetail(Guid id);
        public bool UpdateCartDetail(CartDetail p);

        public List<CartDetail> GetAllCartDetails();
        public CartDetail GetCartDetailById(Guid id);
        public List<CartDetail> GetCartDetailByName(string name);

    }
}
