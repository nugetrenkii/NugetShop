namespace NugetShop.Models
{
    public class Cart
    {
        public Guid CartID { get; set; }
        public string Description { get; set; }
        public virtual IList<CartDetail> CartDetails { get; set; }
        public virtual User User { get; set; }
    }
}
