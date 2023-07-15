using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NugetShop.Models;

namespace NugetShop.Configurations
{
    public class ColorConfiguration
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Color");
            builder.HasKey(x => x.ColorID);
            builder.Property(x => x.ColorName).HasColumnType("nvarchar(1000)");              
            builder.Property(x => x.Status).HasColumnType("int");        
        }
    }
}
