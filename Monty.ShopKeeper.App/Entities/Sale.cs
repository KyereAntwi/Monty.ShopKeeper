using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monty.ShopKeeper.App.Entities;

public class Sale : BaseEntity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public decimal CurrentPricePaid { get; set; }

    public int BasketId { get; set; }
    public  Basket? Basket { get; set; }
}

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Quantity).IsRequired();
        builder.Property(x => x.CurrentPricePaid).IsRequired().HasColumnType("decimal(18,2)");
        builder.HasOne(s => s.Product)
               .WithMany()
               .HasForeignKey(s => s.ProductId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Basket)
                .WithMany(b => b.LineItems)
                .HasForeignKey(s => s.BasketId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}
