using NugetShop.IServices;
using NugetShop.Models;

namespace NugetShop.Services
{
    public class ImageServices : IImageServices
    {
        DataContext context;
        public ImageServices()
        {
            context = new DataContext();
        }
        public bool CreateImage(Image p)
        {
            try
            {
                context.Images.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteImage(Guid id)
        {
            try
            {
                var product = context.Images.Find(id);
                context.Images.Remove(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Image> GetAllImages()
        {
            return context.Images.ToList();
        }

        public Image GetImageById(Guid id)
        {
            return context.Images.FirstOrDefault(p => p.ImageID == id);
        }

        public List<Image> GetImageByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateImage(Image p)
        {
            try
            {
                var product = context.Images.Find(p.ImageID);
                product.Path = p.Path;
                product.Status = p.Status;
                context.Images.Update(product);
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
