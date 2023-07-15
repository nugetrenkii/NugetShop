using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NugetShop.Models;
namespace NugetShop.Configurations
{
    public class SizeConfiguration
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.ToTable("Size");
            builder.HasKey(x => x.SizeID);
            builder.Property(x => x.SizeName).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Status).HasColumnType("int");
        }
    }
}
