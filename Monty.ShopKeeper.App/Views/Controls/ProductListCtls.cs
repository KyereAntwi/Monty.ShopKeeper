using Monty.ShopKeeper.App.Services;
using Monty.ShopKeeper.App.Views.ViewModels;
using System.Globalization;

namespace Monty.ShopKeeper.App.Views.Controls;

public partial class ProductListCtls : UserControl
{
    private readonly IStockServices _stockServices;

    private IReadOnlyCollection<ProductDto> _products = [];
    private int _pageIndex = 1;
    private int _pageSize = 50;

    public ProductListCtls(IStockServices stockServices)
    {
        InitializeComponent();
        _stockServices = stockServices;

        LoadProductsInLv(string.Empty, string.Empty, 0);
        LoadStorages();
    }

    private void SearchProductByCodeTxt_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(SearchProductByCodeTxt.Text) && string.IsNullOrWhiteSpace(SearchProductTxt.Text) && string.IsNullOrWhiteSpace(StorageCB.Text.Trim()))
        {
            GoCodeBtn.Enabled = false;
        }
        else
        {
            GoCodeBtn.Enabled = true;
        }
    }

    private void SearchProductTxt_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(SearchProductByCodeTxt.Text) && string.IsNullOrWhiteSpace(SearchProductTxt.Text) && string.IsNullOrWhiteSpace(StorageCB.Text.Trim()))
        {
            GoCodeBtn.Enabled = false;
        }
        else
        {
            GoCodeBtn.Enabled = true;
        }
    }

    private void GoNameBtn_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(SearchProductByCodeTxt.Text) && string.IsNullOrWhiteSpace(SearchProductTxt.Text) && string.IsNullOrWhiteSpace(StorageCB.Text.Trim()))
            return;

        LoadProductsInLv(string.Empty, SearchProductTxt.Text, 0);
    } // deprecated

    private void GoCodeBtn_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(SearchProductByCodeTxt.Text) && string.IsNullOrWhiteSpace(SearchProductTxt.Text) && string.IsNullOrWhiteSpace(StorageCB.Text.Trim()))
            return;

        LoadProductsInLv(
            SearchProductByCodeTxt.Text.Trim(), 
            SearchProductTxt.Text, 
            StorageCB.SelectedValue == null ? 0 : (int)StorageCB.SelectedValue);
    }

    private void LoadProductsInLv(string code, string name, int storageId)
    {
        ProductsLv.Items.Clear();

        var result = _stockServices.FilterProductsAsync(
            code,
            name,
            storageId,
            _pageIndex,
            _pageSize)
            .GetAwaiter().GetResult();

        _products = [.. result.Value];

        if (_products.Count > 0)
        {
            foreach (var product in _products)
            {
                var newListViewItem = new ListViewItem(product.UniqueIdentifier.ToUpperInvariant());
                newListViewItem.SubItems.Add(product.Name.ToUpper());
                newListViewItem.SubItems.Add(product.CreatedAt.ToLongDateString());
                newListViewItem.SubItems.Add(product.CurrentSellingPrice.ToString("C2", new CultureInfo("en-GH")));
                newListViewItem.SubItems.Add(product.StocksQuantity.ToString());

                ProductsLv.Items.Add(newListViewItem);
            }
        }
    }

    private void RefreshBtn_Click(object sender, EventArgs e)
    {
        LoadProductsInLv(string.Empty, string.Empty, 0);
    }

    private async void AddStockMS_Click(object sender, EventArgs e)
    {
        var selectedProductCode = ProductsLv.SelectedItems[0].SubItems[0];
        var selectedProductName = ProductsLv.SelectedItems[0].SubItems[1];

        var stockFrm = new StockProductFrm(selectedProductCode!.Text, selectedProductName!.Text, _stockServices);
        await stockFrm.ShowDialogAsync();

        LoadProductsInLv(string.Empty, string.Empty, 0);
    }

    private async void StockHistoryMS_Click(object sender, EventArgs e)
    {
        var selectedProductCode = ProductsLv.SelectedItems[0].SubItems[0];
        var selectedProductName = ProductsLv.SelectedItems[0].SubItems[1];

        var stockHistoryFrm = new ProductStockHistoryFrm(selectedProductCode!.Text, selectedProductName!.Text, _stockServices);
        await stockHistoryFrm.ShowDialogAsync();
    }

    private void UpdateProductMS_Click(object sender, EventArgs e)
    {
        var selectedProductCode = ProductsLv.SelectedItems[0].SubItems[0].Text;

        var selectedProduct = _products.FirstOrDefault(p => p.UniqueIdentifier == selectedProductCode);
        var updateProductFrm = new AddProductFrm(_stockServices, selectedProduct!);
        updateProductFrm.ShowDialog();

        LoadProductsInLv(string.Empty, string.Empty, 0);
    }

    private void DeleteProductMS_Click(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show("Are you sure you want to delete the selected product? This action is not reversable.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (dialogResult != DialogResult.Yes)
            return;

        var selectedProductCode = ProductsLv.SelectedItems[0].SubItems[0].Text;
        var selectedProduct = _products.FirstOrDefault(p => p.UniqueIdentifier == selectedProductCode);
        var result = _stockServices.DeleteProductAsync(selectedProduct!.Id).GetAwaiter().GetResult();
        if (result.IsSuccess)
        {
            MessageBox.Show("Product deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProductsInLv(string.Empty, string.Empty, 0);
        }
        else
        {
            MessageBox.Show($"Failed to delete product. Error: {result.Errors.FirstOrDefault()?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ProductsLv_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void AddToStorageMI_Click(object sender, EventArgs e)
    {
        if (ProductsLv.SelectedItems.Count == 0)
            return;

        var selectedProductCode = ProductsLv.SelectedItems[0].SubItems[0];
        var selectedProduct = _products.FirstOrDefault(p => p.UniqueIdentifier == selectedProductCode!.Text);

        var addToStorageFrm = new AddProductToStorageFrm(selectedProduct!.Name, selectedProduct!.UniqueIdentifier.ToUpper(), _stockServices);
        addToStorageFrm.ShowDialog();
    }

    private void LoadStorages()
    {
        var storages = _stockServices.GetAllStoragesAsync().GetAwaiter().GetResult().Value;

        StorageCB.DataSource = storages;
        StorageCB.DisplayMember = "Title";
        StorageCB.ValueMember = "Id";
        StorageCB.SelectedIndex = -1;
    }

    private void StorageCB_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(SearchProductByCodeTxt.Text) && string.IsNullOrWhiteSpace(SearchProductTxt.Text) && string.IsNullOrWhiteSpace(StorageCB.Text.Trim()))
        {
            GoCodeBtn.Enabled = false;
        }
        else
        {
            GoCodeBtn.Enabled = true;
        }
    }
}
