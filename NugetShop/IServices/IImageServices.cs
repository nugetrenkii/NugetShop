using NugetShop.Models;

namespace NugetShop.IServices
{
    public interface IImageServices
    {
        public bool CreateImage(Image p);
        public bool DeleteImage(Guid id);
        public bool UpdateImage(Image p);

        public List<Image> GetAllImages();
        public Image GetImageById(Guid id);
        public List<Image> GetImageByName(string name);
    }
}
