using NugetShop.IServices;
using NugetShop.Models;

namespace NugetShop.Services
{
    public class ColorServices : IColorServices
    {
        DataContext context;

        public ColorServices()
        {
            context = new DataContext();
        }
        public bool CreateColor(Color p)
        {
            try
            {
                context.Color.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteColor(Guid id)
        {
            try
            {
                var product = context.Color.Find(id);
                context.Color.Remove(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Color> GetAllColors()
        {
            return context.Color.ToList();
        }

        public Color GetColorById(Guid id)
        {
            return context.Color.FirstOrDefault(p => p.ColorID == id);
        }

        public List<Color> GetColorByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateColor(Color p)
        {
            try
            {
                var product = context.Color.Find(p.ColorID);
                product.ColorName = p.ColorName;
                product.Status = p.Status;
                context.Color.Update(product);
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
