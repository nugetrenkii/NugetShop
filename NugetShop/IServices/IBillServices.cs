using NugetShop.Models;

namespace NugetShop.IServices
{
    public interface IBillServices
    {
        public bool CreateBill(Bill p);
        public bool DeleteBill(Guid id);
        public bool UpdateBill(Bill p);

        public List<Bill> GetAllBills();
        public Bill GetBillById(Guid id);
        //public List<Bill> GetBillByName(string name);

    }
}
