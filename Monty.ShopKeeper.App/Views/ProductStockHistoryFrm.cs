using Monty.ShopKeeper.App.Entities;
using Monty.ShopKeeper.App.Services;

namespace Monty.ShopKeeper.App.Views;

public partial class ProductStockHistoryFrm : Form
{
    private readonly IStockServices _stockServices;
    private readonly string _productCode;
    private IEnumerable<Stock> _stocks = [];

    public ProductStockHistoryFrm(string code, string name, IStockServices stockServices)
    {
        InitializeComponent();

        _stockServices = stockServices;
        _productCode = code;

        Text = $@"Stock History for ({_productCode})";
        TitleLb.Text = $@"Stock History for ({_productCode}) {name}";

        FetchHistory().GetAwaiter().GetResult();

        TotalStockLb.Text = _stocks.Count().ToString();
        TotalAmountLb.Text = _stocks.Sum(s => s.UnitCostPrice * s.Quantity).ToString("C2");
        AmountExpectedLb.Text = _stocks.Sum(s => s.UnitSellingPrice * s.Quantity).ToString("C2");
        TotalSalesLb.Text = TotalSales().GetAwaiter().GetResult().ToString();

        PopulateStocksLv();
    }

    private async Task FetchHistory()
    {
        var result = await _stockServices.GetAllStocksForAProductAsync(_productCode, 1, 100);
        _stocks = result.Value;
    }

    private void PopulateStocksLv() 
    { 
        StocksLv.Items.Clear();
        foreach (var stock in _stocks)
        {
            var item = new ListViewItem(stock.Id.ToString());
            item.SubItems.Add(stock.Quantity.ToString());
            item.SubItems.Add(stock.QuantityLeft.ToString());
            item.SubItems.Add(stock.UnitCostPrice.ToString("C2"));
            item.SubItems.Add(stock.UnitSellingPrice.ToString("C2"));
            item.SubItems.Add(stock.CreatedAt.ToLongDateString());
            StocksLv.Items.Add(item);
        }
    }

    private async Task<int> TotalSales()
    {
        var result = await _stockServices.TotalUnitsSoldOnProductAsync(_productCode, DateTime.MinValue, DateTime.MinValue);
        return result.Value;
    }
}
