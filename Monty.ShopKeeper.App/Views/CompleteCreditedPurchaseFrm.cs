using Monty.ShopKeeper.App.Entities;
using Monty.ShopKeeper.App.Services;
using Monty.ShopKeeper.App.Utils;

namespace Monty.ShopKeeper.App.Views;

public partial class CompleteCreditedPurchaseFrm : Form
{
    private Basket? _basket;
    private readonly IStockServices _stockServices;
    private decimal _amountToPay = 0;

    public CompleteCreditedPurchaseFrm(Basket basket, IStockServices stockServices)
    {
        InitializeComponent();

        _basket = basket;
        _stockServices = stockServices;
    }

    private void CompleteBtn_Click(object sender, EventArgs e)
    {
        if (_basket == null || AmountReceivedTb.Value == 0)
            return;

        _basket.BalancePaid = BalanceTb.Value;
        _basket.TotalAmountPaid = AmountReceivedTb.Value;

        var result = _stockServices.CompleteACreditedSaleAsync(_basket!).GetAwaiter().GetResult();

        if (result.IsFailed)
        {
            MessageBox.Show($"Operation failed. Error = {result.Errors[0]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var dialogResult = MessageBox.Show("Basket successfully converted to a completed purchase. Do you want to print the receipt?",
            "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (dialogResult == DialogResult.Yes)
            Print.PrintReceipt(_basket!);

        this.Close();
    }

    private void CompleteCreditedPurchaseFrm_Load(object sender, EventArgs e)
    {
        _amountToPay = _basket!.LineItems.Sum(l => l.CurrentPricePaid * l.Quantity);
        TotalToPayLb.Text = $"Total Amount: GHC {_amountToPay}";
    }

    private void AmountReceivedTb_ValueChanged(object sender, EventArgs e)
    {
        if (AmountReceivedTb.Value != 0)
        {
            BalanceTb.Value = Convert.ToDecimal(AmountReceivedTb.Value) - _amountToPay;
            CompleteBtn.Enabled = true;
        }
    }
}
