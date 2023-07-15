namespace NugetShop.Models
{
    public class Image
    {
        public Guid ImageID { get; set; }
        public string Path { get; set; }
        public int Status { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}
