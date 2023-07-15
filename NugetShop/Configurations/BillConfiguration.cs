using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NugetShop.Models;

namespace NugetShop.Configurations
{
    public class BillConfiguration:IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bill");
            builder.HasKey(x => x.BillID);

            builder.Property(x => x.UserID).HasColumnType("UNIQUEIDENTIFIER").
                IsRequired();
            builder.Property(x => x.DateCreated).HasColumnType("DateTime").
                IsRequired();
            builder.Property(x => x.Status).HasColumnType("int").
                IsRequired();
            builder.Property(x => x.TotalAmount).HasColumnType("int").
                IsRequired();
        }

        
    }
}
