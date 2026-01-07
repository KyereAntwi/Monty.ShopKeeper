using Monty.ShopKeeper.App.Services;

namespace Monty.ShopKeeper.App.Views;

public partial class AddProductToStorageFrm : Form
{
    private readonly IStockServices _stockServices;
    private readonly string _productCode;

    public AddProductToStorageFrm(string productName, string code, IStockServices stockServices)
    {
        InitializeComponent();
        TitleLb.Text = $"Add {productName} to Storage";
        _stockServices = stockServices;
        _productCode = code;

        LoadStorages();
    }

    private void LoadStorages()
    {
        var storages = _stockServices.GetAllStoragesAsync().GetAwaiter().GetResult().Value;
        StoragesCB.DataSource = storages;
        StoragesCB.DisplayMember = "Title";
        StoragesCB.ValueMember = "Id";
    }

    private void StoragesCB_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(StoragesCB.Text) || QuantityTxt.Value == 0)
            SaveBtn.Enabled = false;
        else
            SaveBtn.Enabled = true;
    }

    private void SaveBtn_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(StoragesCB.Text) || QuantityTxt.Value == 0)
        {
            MessageBox.Show("Please select a storage and enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var storageId = (int)StoragesCB.SelectedValue!;
        var quantity = (int)QuantityTxt.Value;

        var result = _stockServices.AddProductToStorageAsync(_productCode, storageId, quantity).GetAwaiter().GetResult();

        if (result.IsSuccess)
        {
            MessageBox.Show("Product added to storage successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        else
        {
            MessageBox.Show($"Failed to add product to storage. Error: {string.Join(", ", result.Errors.Select(er => er.Message))}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void QuantityTxt_ValueChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(StoragesCB.Text) || QuantityTxt.Value == 0)
            SaveBtn.Enabled = false;
        else
            SaveBtn.Enabled = true;
    }
}
