using NugetShop.Models;

namespace NugetShop.IServices
{
    public interface IColorServices
    {
        public bool CreateColor(Color p);
        public bool DeleteColor(Guid id);
        public bool UpdateColor(Color p);

        public List<Color> GetAllColors();
        public Color GetColorById(Guid id);
        public List<Color> GetColorByName(string name);
    }
}
