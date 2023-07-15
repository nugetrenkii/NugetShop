using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NugetShop.Models;
namespace _1_ASP.NET_6._0.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasKey(x => x.CartDetailID);
            builder.Property(x => x.ProductID).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Carts).WithMany(p => p.CartDetails).
                HasForeignKey(x => x.UserID).HasConstraintName("FK_Cart");
            builder.HasOne(x => x.Products).WithMany(p => p.CartDetails).
                HasForeignKey(x => x.ProductID).HasConstraintName("FK_Product");
        }
    }
}
