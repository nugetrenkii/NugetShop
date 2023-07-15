using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NugetShop.Models;
namespace _1_ASP.NET_6._0.Configurations
{
    public class UserConfigurarion : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserID);
            builder.Property(x => x.UserRoleID).HasColumnType("UNIQUEIDENTIFIER ").IsRequired();
            builder.Property(x => x.UserName).HasColumnType("nchar(256)");
            builder.Property(x => x.Password).HasColumnType("nchar(256)");
            builder.Property(x => x.Phone).HasColumnType("nvarchar(20)");
            builder.HasOne(p => p.UserRoles).WithMany(p => p.Users).
                HasForeignKey(p => p.UserRoleID);
        }
    }
}
