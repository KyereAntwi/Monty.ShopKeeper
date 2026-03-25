using Monty.ShopKeeper.App.Entities;
using Monty.ShopKeeper.App.Entities.Enums;
using Monty.ShopKeeper.App.Services;
using Monty.ShopKeeper.App.Utils;

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

        if (!string.IsNullOrWhiteSpace(_basket.Comments))
        {
            CommentTxt.Text = _basket.Comments;
        }

        if (_basket.BalancePaid > 0)
        {
            BalanceTxt.Text = _basket.BalancePaid.ToString("C2");
        }

        if (_basket.Id > 0)
        {
            SubmitBtn.Enabled = false;
        }
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
        if (AmountReceivedTxt.Value == 0 && !CreditPurchaseCB.Checked)
            return;

        if (_basket.PurchaseType == PurchaseType.Credit && string.IsNullOrWhiteSpace(CommentTxt.Text))
        {
            MessageBox.Show("A comment on this sale for credits are mandatory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }


        _basket.TotalAmountPaid = AmountReceivedTxt.Value;
        _basket.BalancePaid = AmountReceivedTxt.Value - _totalExpectedToPay;

        var result = _stockServices.MakeASaleAsync(_basket).GetAwaiter().GetResult();

        if (result.IsFailed)
        {
            MessageBox.Show($"Error processing basket. Error: {result.Errors[0]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (_basket.PurchaseType == PurchaseType.Debit)
        {
            // print receipt using basket as the sale details with the printer services
            Print.PrintReceipt(_basket);
        }


        MessageBox.Show("Basket processed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.Close();
    }

    private void CommentTxt_TextChanged(object sender, EventArgs e)
    {
        _basket.Comments = CommentTxt.Text.Trim();
    }

    private void CreditPurchaseCB_CheckedChanged(object sender, EventArgs e)
    {
        if (!CreditPurchaseCB.Checked)
        {
            _basket.PurchaseType = PurchaseType.Debit;

            AmountReceivedTxt.Enabled = true;
            BalanceTxt.Enabled = true;
        } else
        {
            _basket.PurchaseType = PurchaseType.Credit;

            AmountReceivedTxt.Enabled = false;
            BalanceTxt.Enabled = false;
        }


        SubmitBtn.Enabled = true;
    }
}
