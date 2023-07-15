using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NugetShop.Models;
namespace _1_ASP.NET_6._0.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(p => p.CartID);
            builder.Property(p => p.Description).HasColumnType("nvarchar(1000)");
            builder.HasOne(x => x.User).WithOne(y => y.Carts).HasForeignKey<Cart>(x => x.CartID);
        }
    }
}
