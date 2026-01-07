using Monty.ShopKeeper.App.Services;

namespace Monty.ShopKeeper.App.Views.Controls;

public partial class SalesHistoryCtls : UserControl
{
    private readonly IStockServices _stockServices;
    private string _productCodeFilter = string.Empty;
    private DateTime _startDateFilter = DateTime.MinValue;
    private DateTime _endDateFilter = DateTime.MaxValue;
    private int _currentPage = 1;
    private int _pageSize = 100;

    public SalesHistoryCtls(IStockServices stockServices)
    {
        InitializeComponent();
        _stockServices = stockServices;

        LoadSalesHistory();
    }

    private void LoadSalesHistory()
    {
        var salesHistory = _stockServices
            .GetAllSalesAsync(_productCodeFilter.Trim().ToUpper(), _startDateFilter, _endDateFilter, _currentPage, _pageSize)
            .GetAwaiter()
            .GetResult();

        SalesHistoryLv.Items.Clear();

        var listViewGroup = new ListViewGroup();
        foreach (var sale in salesHistory.Value)
        {
            var listViewItem = new ListViewItem
            {
                Text = $"{sale.CreatedAt:g} - Total Paid: ${sale.TotalAmountPaid:C:2}"
            };

            foreach (var lineItem in sale.LineItems)
            {
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = sale.Id.ToString() });
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = lineItem.Product!.Name });
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = lineItem.Product!.UniqueIdentifier.ToUpper() });
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = lineItem.Quantity.ToString() });
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = lineItem.CurrentPricePaid.ToString("C:2") });
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = sale.Comments });
            }

            listViewGroup.Items.Add(listViewItem);
        }

        SalesHistoryLv.Groups.Add(listViewGroup);
    }

    private void FilterBtn_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_productCodeFilter) && _startDateFilter == DateTime.MinValue && _endDateFilter == DateTime.MinValue)
            return;

        LoadSalesHistory();
    }

    private void CodeTxt_TextChanged(object sender, EventArgs e)
    {
        _productCodeFilter = CodeTxt.Text;
    }

    private void FromDTP_ValueChanged(object sender, EventArgs e)
    {
        _startDateFilter = FromDTP.Value;
    }

    private void ToDTP_ValueChanged(object sender, EventArgs e)
    {
        _endDateFilter = ToDTP.Value;
    }
}
