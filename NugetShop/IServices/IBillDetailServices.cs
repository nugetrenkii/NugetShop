using NugetShop.Models;

namespace NugetShop.IServices
{
    public interface IBillDetailServices
    {
        public bool CreateBillDetail(BillDetail p);
        public bool DeleteBillDetail(Guid id);
        public bool UpdateBillDetail(BillDetail p);

        public List<BillDetail> GetAllBillDetails();
        public BillDetail GetBillDetailById(Guid id);

        //public List<BillDetail> GetBillDetailByName(string name);

    }
}
