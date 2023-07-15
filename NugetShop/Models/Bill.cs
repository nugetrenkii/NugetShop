namespace NugetShop.Models
{
    public class Bill
    {
        public Guid BillID { get; set; }
        public Guid UserID { get; set; }
        public DateTime DateCreated { get; set; }
        public int TotalAmount { get; set; }
        public int Status { get; set; }
        public virtual IEnumerable<BillDetail> BillDetails { get; set; }
        public virtual User User { get; set; }
    }
}
