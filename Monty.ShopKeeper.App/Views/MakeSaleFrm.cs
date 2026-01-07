using Monty.ShopKeeper.App.Entities;
using Monty.ShopKeeper.App.Services;

namespace Monty.ShopKeeper.App.Views;

public partial class MakeSaleFrm : Form
{
    private Basket _basket;
    private readonly IStockServices _stockServices;
    private decimal _totalExpectedToPay;

    public MakeSaleFrm(Basket basket, IStockServices stockServices)
    {
        InitializeComponent();

        _basket = basket;
        _stockServices = stockServices;
        LoadBasketListBox();
    }

    private void LoadBasketListBox()
    {
        if (_basket == null)
        {
            MessageBox.Show("Basket cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }

        LineItemsLB.Items.Clear();
        foreach (var item in _basket!.LineItems)
        {
            LineItemsLB.Items.Add($"{item.Product?.Name} - {item.Product?.UniqueIdentifier}: Quantity ({item.Quantity})");
        }

        _totalExpectedToPay = _basket.LineItems.Sum(i => i.Quantity * i.CurrentPricePaid);
        TotalLb.Text = "Total to pay: " + _totalExpectedToPay.ToString("C2");
    }

    private void AmountReceivedTxt_ValueChanged(object sender, EventArgs e)
    {
        if (_basket is null || AmountReceivedTxt.Value == 0)
            SubmitBtn.Enabled = false;
        else
        {
            SubmitBtn.Enabled = true;
            BalanceTxt.Text = ((decimal)AmountReceivedTxt.Value - _totalExpectedToPay).ToString("C2");
        }
    }

    private void SubmitBtn_Click(object sender, EventArgs e)
    {
        if (AmountReceivedTxt.Value == 0)
            return;

        _basket.TotalAmountPaid = AmountReceivedTxt.Value;
        _basket.BalancePaid = AmountReceivedTxt.Value - _totalExpectedToPay;

        var result = _stockServices.MakeASaleAsync(_basket).GetAwaiter().GetResult();

        if (result.IsFailed)
        {
            MessageBox.Show($"Error processing basket. Error: {result.Errors[0]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        MessageBox.Show("Basket processed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.Close();
    }
}
