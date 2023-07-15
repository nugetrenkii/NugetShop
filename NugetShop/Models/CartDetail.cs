namespace NugetShop.Models
{
    public class CartDetail
    {
        public Guid CartDetailID { get; set; }
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }

        public virtual Cart Carts { get; set; }
        public virtual Product Products { get; set; }
    }
}
