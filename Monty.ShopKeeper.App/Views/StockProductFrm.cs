using Monty.ShopKeeper.App.Services;

namespace Monty.ShopKeeper.App.Views;

public partial class StockProductFrm : Form
{
    private readonly string _uniqueIdentifier = string.Empty;
    private readonly string _productName = string.Empty;
    private readonly IStockServices _stockServices;

    public StockProductFrm(string uniqueIdentitfier, string name, IStockServices stockServices)
    {
        InitializeComponent();

        _uniqueIdentifier = uniqueIdentitfier;
        _productName = name;
        _stockServices = stockServices;

        this.Text = $"{_uniqueIdentifier} | {_productName} - Stocking Form";
        TitleLb.Text = $"Stocking Product: {_productName}";
    }

    private void ClearBtn_Click(object sender, EventArgs e)
    {
        QuantityTxt.Value = 0;
        CostPriceTxt.Value = 0;
        SellingPriceTxt.Value = 0;

        QuantityTxt.Focus();
        SaveBtn.Enabled = false;
    }

    private void SaveBtn_Click(object sender, EventArgs e)
    {
        if (QuantityTxt.Value <= 0 && CostPriceTxt.Value <= 0 && SellingPriceTxt.Value <= 0)
        {
            MessageBox.Show("All fields are required and must be above 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        int quantity = int.Parse(QuantityTxt.Text);
        decimal costPrice = decimal.Parse(CostPriceTxt.Text);
        decimal sellingPrice = decimal.Parse(SellingPriceTxt.Text);

        var result = _stockServices.StockProductAsync(
            _uniqueIdentifier,
            quantity,
            costPrice,
            sellingPrice).GetAwaiter().GetResult();

        if (result.IsFailed)
        {
            MessageBox.Show($"There was a problem stocking product. Error = {result.Errors[0]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        MessageBox.Show("Product stocked successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.Close();
    }

    private void QuantityTxt_TextChanged(object sender, EventArgs e)
    {
    }
    private void CostPriceTxt_TextChanged(object sender, EventArgs e)
    {
    }
    private void SellingPriceTxt_TextChanged(object sender, EventArgs e)
    {  
    }

    private void QuantityTxt_ValueChanged(object sender, EventArgs e)
    {
        if (QuantityTxt.Value > 0 && CostPriceTxt.Value > 0 && SellingPriceTxt.Value > 0)
        {
            SaveBtn.Enabled = true;
            var profitPerUnit = SellingPriceTxt.Value - CostPriceTxt.Value;
            ProfitLb.Text = $"Profit per Unit: {profitPerUnit:C2} and Total Profit: {QuantityTxt.Value * profitPerUnit:C2}";
        }
        else
        {
            SaveBtn.Enabled = false;
        }
    }

    private void CostPriceTxt_ValueChanged(object sender, EventArgs e)
    {
        if (QuantityTxt.Value > 0 && CostPriceTxt.Value > 0 && SellingPriceTxt.Value > 0)
        {
            SaveBtn.Enabled = true;

            var profitPerUnit = SellingPriceTxt.Value - CostPriceTxt.Value;
            ProfitLb.Text = $"Profit per Unit: {profitPerUnit:C2} and Total Profit: {QuantityTxt.Value * profitPerUnit:C2}";
        }
        else
        {
            SaveBtn.Enabled = false;
        }
    }

    private void SellingPriceTxt_ValueChanged(object sender, EventArgs e)
    {
        if (QuantityTxt.Value > 0 && CostPriceTxt.Value > 0 && SellingPriceTxt.Value > 0)
        {
            SaveBtn.Enabled = true;
            var profitPerUnit = SellingPriceTxt.Value - CostPriceTxt.Value;
            ProfitLb.Text = $"Profit per Unit: {profitPerUnit:C2} and Total Profit: {QuantityTxt.Value * profitPerUnit:C2}";
        }
        else
        {
            SaveBtn.Enabled = false;
        }
    }
}
