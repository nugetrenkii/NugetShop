using Microsoft.EntityFrameworkCore;
using NugetShop.IServices;
using NugetShop.Models;

namespace NugetShop.Services
{
    public class BillDetailServices : IBillDetailServices
    {
        DataContext context;

        public BillDetailServices()
        {
            context = new DataContext();
        }

        
        public bool CreateBillDetail(BillDetail p)
        {
            try
            {
                context.BillDetails.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteBillDetail(Guid id)
        {
            try
            {
                var product = context.BillDetails.Find(id);
                context.BillDetails.Remove(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<BillDetail> GetAllBillDetails()
        {
            return context.BillDetails.Include("Products").ToList();
        }

        public BillDetail GetBillDetailById(Guid id)
        {
            return context.BillDetails.FirstOrDefault(p => p.BillDetailID == id);
        }

        //public List<BillDetail> GetBillDetailByName(string name)
        //{
        //    return context.BillDetail.Where(p => p.Name.Contains(name)).ToList();
        //}

        public bool UpdateBillDetail(BillDetail p)
        {
            try
            {
                var product = context.BillDetails.Find(p.BillDetailID);
                product.Quantity = p.Quantity;
                product.Price = p.Price;
                context.BillDetails.Update(product);
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
