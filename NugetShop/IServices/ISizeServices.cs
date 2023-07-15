using NugetShop.Models;

namespace NugetShop.IServices
{
    public interface ISizeServices
    {
        public bool CreateSize(Size p);
        public bool DeleteSize(Guid id);
        public bool UpdateSize(Size p);

        public List<Size> GetAllSizes();
        public Size GetSizeById(Guid id);
        public List<Size> GetSizeByName(string name);
    }
}
