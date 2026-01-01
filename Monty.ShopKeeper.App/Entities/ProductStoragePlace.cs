using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monty.ShopKeeper.App.Entities;

public class ProductStoragePlace : BaseEntity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int StoragePlaceId { get; set; }
    public StoragePlace? StoragePlace { get; set; }

    public int QuantiyOfProductInStorage { get; set; }
}

public class ProductStoragePlaceConfiguration : IEntityTypeConfiguration<ProductStoragePlace>
{
    public void Configure(EntityTypeBuilder<ProductStoragePlace> builder)
    {
        builder.HasKey(psp => psp.Id);

        builder.Property(psp => psp.QuantiyOfProductInStorage).IsRequired();

        builder.HasOne(psp => psp.Product)
               .WithMany()
               .HasForeignKey(psp => psp.ProductId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(psp => psp.StoragePlace)
               .WithMany()
               .HasForeignKey(psp => psp.StoragePlaceId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
