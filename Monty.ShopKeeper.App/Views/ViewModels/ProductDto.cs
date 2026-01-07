namespace Monty.ShopKeeper.App.Views.ViewModels;

public record ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string UniqueIdentifier { get; set; } = string.Empty;
    public byte[]? Image { get; set; }
    public decimal CurrentSellingPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public int StocksQuantity { get; set; }
}
