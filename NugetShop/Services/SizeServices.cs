using NugetShop.IServices;
using NugetShop.Models;

namespace NugetShop.Services
{
    public class SizeServices : ISizeServices
    {
        DataContext context;
        public SizeServices()
        {
            context = new DataContext();
        }
        public bool CreateSize(Size p)
        {
            try
            {
                context.Size.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteSize(Guid id)
        {
            try
            {
                var Size = context.Size.Find(id);
                context.Size.Remove(Size);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Size> GetAllSizes()
        {
            return context.Size.ToList();
        }

        public Size GetSizeById(Guid id)
        {
            return context.Size.FirstOrDefault(p => p.SizeID == id);
        }

        public List<Size> GetSizeByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSize(Size p)
        {
            try
            {
                var Size = context.Size.Find(p.SizeID);
                Size.SizeName = p.SizeName;
                Size.Status = p.Status;
                context.Size.Update(Size);
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
