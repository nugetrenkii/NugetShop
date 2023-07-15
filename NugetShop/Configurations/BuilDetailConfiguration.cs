using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NugetShop.Models;
namespace NugetShop.Configurations
{
    public class BuilDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(p => p.BillDetailID);

            builder.Property(p => p.BillID).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(p => p.ProductID).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(p => p.Price).HasColumnType("int");
            builder.Property(p => p.Quantity).HasColumnType("int");

            builder.HasOne(x => x.Bill).WithMany(x => x.BillDetails).
                HasForeignKey(x => x.BillID);
            builder.HasOne(x => x.Products).WithMany(x => x.BillDetails).
                HasForeignKey(x => x.ProductID);
        }
    }
}
