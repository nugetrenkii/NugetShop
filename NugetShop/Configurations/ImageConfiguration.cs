using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NugetShop.Models;

namespace NugetShop.Configurations
{
    public class ImageConfiguration
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Image");
            builder.HasKey(x => x.ImageID);
            builder.Property(x => x.Path).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Status).HasColumnType("int");
        }
    }
}
