using NugetShop.IServices;
using NugetShop.Models;

namespace NugetShop.Services
{
    public class ProductServices : IProductServices
    {
        DataContext context;

        public ProductServices()
        {
            context = new DataContext();
        }
        public bool CreateProduct(Product p)
        {
            try
            {
                context.Products.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {
                var product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public Product GetProductById(Guid id)
        {
            return context.Products.FirstOrDefault(p => p.ProductID == id);
        }

        public List<Product> GetProductByName(string name)
        {
            return context.Products.Where(p => p.ProductName.Contains(name)).ToList();
        }

        public bool UpdateProduct(Product p)
        {
            try
            {
                var product = context.Products.Find(p.ProductID);
                    product.ProductName = p.ProductName;
                    product.Colors = p.Colors;
                    product.Price = p.Price;
                    product.Description = p.Description;
                    product.Size = p.Size;
                    product.Quantity = p.Quantity;
                    product.Status = p.Status;
                    context.Products.Update(product);
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
