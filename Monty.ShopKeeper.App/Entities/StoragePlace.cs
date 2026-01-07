using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monty.ShopKeeper.App.Entities;

public class StoragePlace : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public int Order { get; set; }
}

public class StoragePlaceConfiguration : IEntityTypeConfiguration<StoragePlace>
{
    public void Configure(EntityTypeBuilder<StoragePlace> builder)
    {
        builder.HasKey(sp => sp.Id);
        builder.Property(sp => sp.Title).IsRequired().HasMaxLength(200);
    }
}
