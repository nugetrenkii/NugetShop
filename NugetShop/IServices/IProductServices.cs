using NugetShop.Models;

namespace NugetShop.IServices
{
    public interface IProductServices
    {
        public bool CreateProduct(Product p);
        public bool DeleteProduct(Guid id);
        public bool UpdateProduct(Product p);

        public List<Product> GetAllProducts();
        public Product GetProductById(Guid id);
        public List<Product> GetProductByName(string name);


    }
}
