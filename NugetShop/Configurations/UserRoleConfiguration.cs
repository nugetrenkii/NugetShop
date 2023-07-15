using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NugetShop.Models;
namespace _1_ASP.NET_6._0.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(p => p.UserRoleID);
            builder.Property(p => p.Description).HasColumnType("nvarchar(100)");
            builder.Property(p => p.RoleName).HasColumnType("nvarchar(100)");
        }
    }
}
