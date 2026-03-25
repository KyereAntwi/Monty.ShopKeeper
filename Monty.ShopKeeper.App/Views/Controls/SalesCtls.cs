using Monty.ShopKeeper.App.Entities;
using Monty.ShopKeeper.App.Services;
using Monty.ShopKeeper.App.Utils;

namespace Monty.ShopKeeper.App.Views.Controls;

public partial class SalesCtls : UserControl
{
    private readonly IStockServices _stockServices;
    private bool _basketCanBeProcessed = false;
    private Basket _basket = new();
    private IEnumerable<Basket> _basketHistory = [];
    decimal _actualTotal = 0m;

    public SalesCtls(IStockServices stockServices)
    {
        InitializeComponent();

        TodayLb.Text = $"Today - {DateTime.Now:D} Sales Logging.";
        SendBtn.Enabled = _basketCanBeProcessed;
        _stockServices = stockServices;

        LoadBasketHistory();
    }

    private void CodeTxt_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(CodeTxt.Text.Trim()) || QuantityTxt.Value == 0)
            AddBtn.Enabled = false;
        else
            AddBtn.Enabled = true;
    }

    private void QuantityTxt_ValueChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(CodeTxt.Text.Trim()) || QuantityTxt.Value == 0)
            AddBtn.Enabled = false;
        else
            AddBtn.Enabled = true;
    }

    private void AddBtn_Click(object sender, EventArgs e)
    {
        var result = _stockServices.FilterProductsAsync(CodeTxt.Text.Trim(), string.Empty, 0, 1, 1).GetAwaiter().GetResult();

        if (!result.Value.Any())
        {
            MessageBox.Show($"Product with code {CodeTxt.Text} does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var product = result.Value.First();

        _basket.LineItems.Add(new Sale
        {
            ProductId = product.Id,
            Product = new Product { UniqueIdentifier = product.UniqueIdentifier, Name = product.Name },
            Quantity = (int)QuantityTxt.Value,
            CurrentPricePaid = product.CurrentSellingPrice
        });

        BasketLb.Items.Add($"Product: {product.UniqueIdentifier} - {product.Name}, Quantity: {QuantityTxt.Value}");
        _actualTotal = (_actualTotal + (product.CurrentSellingPrice * (int)QuantityTxt.Value));
        BasketTotalLb.Text = _actualTotal.ToString("C2");
        SendBtn.Enabled = true;

        CodeTxt.Clear();
        QuantityTxt.Value = 0;
        AddBtn.Enabled = false;
    }

    private void LoadBasketHistory()
    {
        var result = _stockServices.GetAllSalesAsync(string.Empty, DateTime.Now, DateTime.Now, 1, 100, null, false, null).GetAwaiter().GetResult();
        _basketHistory = result.Value;

        if (!_basketHistory.Any())
            return;

        BasketHistoryLv.Items.Clear();

        foreach (var item in _basketHistory)
        {
            var listViewItem = new ListViewItem(item.Id.ToString());
            listViewItem.SubItems.Add(item.CreatedAt.ToLongTimeString());
            listViewItem.SubItems.Add(item.LineItems.Sum(i => i.Quantity * i.CurrentPricePaid).ToString("C2"));

            listViewItem.SubItems.Add(item.TotalAmountPaid.ToString("C2"));
            listViewItem.SubItems.Add(item.BalancePaid.ToString("C2"));
            listViewItem.SubItems.Add(item.Comments);

            BasketHistoryLv.Items.Add(listViewItem);
        }

        TotalLb.Text = _basketHistory.Sum(b => b.LineItems.Sum(i => i.Quantity * i.CurrentPricePaid)).ToString("C2");
    }

    private void SendBtn_Click(object sender, EventArgs e)
    {
        var finalFrm = new MakeSaleFrm(_basket, _stockServices);
        finalFrm.ShowDialog();

        _basket = new Basket();
        ClearForm();

        LoadBasketHistory();
        _actualTotal = 0m;
    }

    private void ReloadBtn_Click(object sender, EventArgs e)
    {
        LoadBasketHistory();
        ClearForm();
    }

    private void ClearBtn_Click(object sender, EventArgs e)
    {
        ClearForm();
    }

    private void ClearForm()
    {
        CodeTxt.Clear();
        QuantityTxt.Value = 0;
        BasketLb.Items.Clear();
        AddBtn.Enabled = false;
        BasketLb.Items.Clear();
        BasketTotalLb.Text = "0";
    }

    private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (BasketHistoryLv.SelectedItems.Count == 0)
        {
            MessageBox.Show("No item is selected. Make the right click on the Id number of the item to ensure item is selected.", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var listItem = BasketHistoryLv.SelectedItems[0];
        var selectedSale = _basketHistory.FirstOrDefault(item => item.Id.ToString() == listItem.Text);

        if (selectedSale == null) return;

        var form = new MakeSaleFrm(selectedSale, _stockServices);
        form.ShowDialog();
    }

    private void printReceiptToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (BasketHistoryLv.SelectedItems.Count == 0)
        {
            MessageBox.Show("No item is selected. Make the right click on the Id number of the item to ensure item is selected.", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var dialogResult = MessageBox.Show("This will print the receipt for the selected sale. Do you want to continue?", "Print Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (dialogResult == DialogResult.No)
            return;

        var listItem = BasketHistoryLv.SelectedItems[0];
        var selectedSale = _basketHistory.FirstOrDefault(item => item.Id.ToString() == listItem.Text);

        if (selectedSale == null) return;

        Print.PrintReceipt(selectedSale);
    }

    private void makeAReturnOnThisSaleToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }
}
