namespace NugetShop.Models
{
    public class Color
    {
        public Guid ColorID { get; set; }
        public string ColorName { get; set; }
        public int Status { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
