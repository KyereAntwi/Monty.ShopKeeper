using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monty.ShopKeeper.App.Entities;

public class Stock : BaseEntity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public int QuantityLeft { get; set; }
    public decimal UnitCostPrice { get; set; }
    public decimal UnitSellingPrice { get; set; }
}

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.UnitCostPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(x => x.UnitSellingPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.HasOne(x => x.Product)
               .WithMany()
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
