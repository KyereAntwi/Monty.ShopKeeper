using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monty.ShopKeeper.App.Entities.Enums;

namespace Monty.ShopKeeper.App.Entities;

public class ApplicationUser : BaseEntity
{
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public RoleType Role { get; set; } = RoleType.Administrator;
}

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(au => au.Id);

        builder.Property(au => au.UserName)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(au => au.PasswordHash)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(au => au.Role).HasDefaultValue(RoleType.Administrator);
    }
}
