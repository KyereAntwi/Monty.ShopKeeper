using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monty.ShopKeeper.App.Entities;

public class Basket : BaseEntity
{
    public ICollection<Sale> LineItems { get; set; } = [];
    public decimal TotalAmountPaid { get; set; }
    public decimal BalancePaid { get; set; }
    public string Comments { get; set; } = string.Empty;
}

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.TotalAmountPaid).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(b => b.BalancePaid).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(b => b.Comments).HasMaxLength(500);

        builder.HasMany(b => b.LineItems)
               .WithOne(s => s.Basket)
               .HasForeignKey(s => s.BasketId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
