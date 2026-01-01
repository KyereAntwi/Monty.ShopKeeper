using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monty.ShopKeeper.App.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string UniqueIdentifier { get; set; } = string.Empty;
    public byte[]? Image { get; set; }

    // Navigation properties can be added here if needed
    public virtual ICollection<Stock> Stocks { get; set; } = [];
    public virtual ICollection<Sale> Sales { get; set; } = [];
    public virtual ICollection<ProductStoragePlace> ProductStoragePlaces { get; set; } = [];
}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.UniqueIdentifier).IsRequired().HasMaxLength(5);
        builder.HasIndex(x => x.UniqueIdentifier).IsUnique();
        builder.Property(x => x.Description).HasMaxLength(1000);
    }
}
