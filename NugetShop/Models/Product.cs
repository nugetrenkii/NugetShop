namespace NugetShop.Models
{
    public class Product
    {
        public Guid ProductID { get; set; }
        public Guid ColorID { get; set; }
        public Guid SizeID { get; set; }
        public Guid ImageID { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }


        public virtual List<BillDetail> BillDetails { get; set; }
        public virtual List<CartDetail> CartDetails { get; set; }

        public virtual Color Colors { get; set; }
        public virtual Size Size { get; set; }
        public virtual Image Image { get; set; }
    }
}
