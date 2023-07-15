
using Microsoft.EntityFrameworkCore;
using NugetShop.IServices;
using NugetShop.Models;

namespace NugetShop.Services
{
    public class BillServices : IBillServices
    {
        DataContext context;

        public BillServices()
        {
            context= new DataContext();
        }
        public bool CreateBill(Bill p)
        {
            try
            {
                context.Bills.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteBill(Guid id)
        {
            try
            {
                var product = context.Bills.Find(id);
                context.Bills.Remove(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Bill> GetAllBills()
        {
            return context.Bills.Include("User").ToList();
        }

        public Bill GetBillById(Guid id)
        {
            return context.Bills.FirstOrDefault(p => p.BillID == id);
        }

        //public List<Bill> GetBillByName(string name)
        //{
        //    return context.Bill.Where(p => p.Name.Contains(name)).ToList();
        //}

        public bool UpdateBill(Bill p)
        {
            try
            {
                var product = context.Bills.Find(p.BillID);
                product.DateCreated = p.DateCreated;               
                product.TotalAmount = p.TotalAmount;               
                product.Status = p.Status;
                context.Bills.Update(product);
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
