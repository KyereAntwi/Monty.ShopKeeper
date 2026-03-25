using Monty.ShopKeeper.App.Entities;
using Monty.ShopKeeper.App.Entities.Enums;
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
    private PurchaseType? _purchaseType = null;
    private bool _returned = false;
    private string? _keyword = string.Empty;
    private IEnumerable<Basket> _salesHistory = [];

    public SalesHistoryCtls(IStockServices stockServices)
    {
        InitializeComponent();
        _stockServices = stockServices;

        LoadSalesHistory();
    }

    private void LoadSalesHistory()
    {
        _salesHistory = _stockServices
            .GetAllSalesAsync(_productCodeFilter.Trim().ToUpper(), _startDateFilter, _endDateFilter, _currentPage, _pageSize, _purchaseType, _returned, _keyword)
            .GetAwaiter()
            .GetResult()
            .Value;

        SalesHistoryLv.Items.Clear();


        foreach (var sale in _salesHistory)
        {
            var listViewItem = new ListViewItem(sale.Id.ToString());

            foreach (var lineItem in sale.LineItems)
            {
                //listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = $"{sale.Id} - {lineItem.Product!.Id}" });
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = lineItem.Product!.Name });
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = lineItem.Product!.UniqueIdentifier.ToUpper() });
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = lineItem.Quantity.ToString() });
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = lineItem.CurrentPricePaid.ToString("C2") });
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = sale.Comments });
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = sale.PurchaseType.ToString() });
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = sale.Returned ? "Returned Sale" : "Not Returned" });
            }

            SalesHistoryLv.Items.Add(listViewItem);

            var listViewGroup = new ListViewGroup($"Total Paid: ${sale.TotalAmountPaid:C:2}");
            listViewGroup.Header = $"Total Paid: ${sale.TotalAmountPaid:C:2}";
            listViewGroup.Name = $"{sale.CreatedAt:g} Total Items: {sale.LineItems.Count}";
            //listViewGroup.Items.Add(listViewItem);

            SalesHistoryLv.Groups.Add(listViewGroup);
        }

        TotalTxt.Text = "Total Amount Paid: " +
            _salesHistory
            .Where(s => !s.Returned && s.PurchaseType != PurchaseType.Credit)
            .Sum(s => s.TotalAmountPaid).ToString("C2");
    }

    private void FilterBtn_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_productCodeFilter) && _startDateFilter == DateTime.MinValue &&
            _endDateFilter == DateTime.MinValue && _purchaseType == null && _returned == false && string.IsNullOrEmpty(_keyword))
            return;

        LoadSalesHistory();
    }

    private void CodeTxt_TextChanged(object sender, EventArgs e)
    {
        _productCodeFilter = CodeTxt.Text.Trim();
    }

    private void FromDTP_ValueChanged(object sender, EventArgs e)
    {
        _startDateFilter = FromDTP.Value;
    }

    private void ToDTP_ValueChanged(object sender, EventArgs e)
    {
        _endDateFilter = ToDTP.Value;
    }

    private void PurchaseTypeCB_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PurchaseTypeCB.Text.Trim().Contains("Credit"))
        {
            _purchaseType = PurchaseType.Credit;
        }
        else if (PurchaseTypeCB.Text.Trim().Contains("Debit"))
        {
            _purchaseType = PurchaseType.Debit;
        }
        else
        {
            _purchaseType = null;
        }
    }

    private void ReturnedCB_CheckedChanged(object sender, EventArgs e)
    {
        _returned = !_returned;
    }

    private void completePurchaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (SalesHistoryLv.SelectedItems.Count == 0)
            return;

        var selectedItem = SalesHistoryLv.SelectedItems[0];
        if (selectedItem == null) return;

        var selectedBasket = _salesHistory.FirstOrDefault(s => s.Id == Convert.ToInt32(selectedItem.Text));

        if (selectedBasket!.PurchaseType == PurchaseType.Debit)
        {
            MessageBox.Show("Purchase of selected basket has already been completed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var dialogResult = MessageBox.Show("This operation would transform this Basket into a completed purchase (Debit purchase). Are you sure you want to proceed?",
            "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (dialogResult == DialogResult.No)
            return;

        var completePurchaseFrm = new CompleteCreditedPurchaseFrm(selectedBasket, _stockServices);
        completePurchaseFrm.ShowDialog();

        LoadSalesHistory();
    }

    private void KeywordTxt_TextChanged(object sender, EventArgs e)
    {
        _keyword = KeywordTxt.Text.Trim();
    }
}
