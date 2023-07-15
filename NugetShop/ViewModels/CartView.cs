namespace NugetShop.ViewModels
{
    public class CartView
    {
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
