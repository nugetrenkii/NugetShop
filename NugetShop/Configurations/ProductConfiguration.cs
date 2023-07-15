using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NugetShop.Models;
namespace _1_ASP.NET_6._0.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductID);
            builder.Property(x => x.ColorID).HasColumnType("UNIQUEIDENTIFIER ").IsRequired();
            builder.Property(x => x.SizeID).HasColumnType("UNIQUEIDENTIFIER ").IsRequired();
            builder.Property(x => x.ImageID).HasColumnType("UNIQUEIDENTIFIER ").IsRequired();
            builder.Property(x => x.Quantity).HasColumnType("int ");
            builder.Property(p => p.ProductName).HasColumnType("nvarchar(100)");
            builder.Property(p => p.Price).HasColumnType("int");
            builder.Property(p => p.Status).HasColumnType("int");
            builder.Property(p => p.Description).IsUnicode(true).
                HasMaxLength(100).IsFixedLength();

            builder.HasOne(x => x.Colors).WithMany(y => y.Products).HasForeignKey(x => x.ColorID);
            builder.HasOne(x => x.Size).WithMany(y => y.Products).HasForeignKey(x => x.SizeID);
            builder.HasOne(x => x.Image).WithMany(y => y.Products).HasForeignKey(x => x.ImageID);

        }
    }
}
