using FluentResults;
using Monty.ShopKeeper.App.Entities;
using Monty.ShopKeeper.App.Services;
using Monty.ShopKeeper.App.Views.ViewModels;

namespace Monty.ShopKeeper.App.Views;

public partial class AddProductFrm : Form
{
    private readonly IStockServices _stockServices;
    private readonly ProductDto? _selectedProduct;

    public AddProductFrm(IStockServices stockServices)
    {
        InitializeComponent();
        _stockServices = stockServices;   
    }

    public AddProductFrm(IStockServices stockServices, ProductDto product)
    {
        InitializeComponent();

        _stockServices = stockServices;
        _selectedProduct = product;

        if (_selectedProduct is not null)
        {
            AddProductTitleLb.Text = "Edit Product";
            ProductNameTxt.Text = _selectedProduct.Name;
            ProductDescriptionTxt.Text = _selectedProduct.Description;
            ProductUniueIdentifierTxt.Text = _selectedProduct.UniqueIdentifier;
            SaveBtn.Text = "Update Product";
            SaveBtn.Enabled = true;
        }
    }

    private void ClearBtn_Click(object sender, EventArgs e)
    {
        ProductNameTxt.Clear();
        ProductDescriptionTxt.Clear();
        ProductUniueIdentifierTxt.Clear();
        ProductNameTxt.Focus();
    }

    private void SaveBtn_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(ProductNameTxt.Text) || string.IsNullOrWhiteSpace(ProductUniueIdentifierTxt.Text))
        {
            MessageBox.Show("Product name and Unique identifier are required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var product = new Product
        {
            Name = ProductNameTxt.Text.Trim(),
            Description = ProductDescriptionTxt.Text.Trim(),
            UniqueIdentifier = ProductUniueIdentifierTxt.Text.Trim()
        };

        Result result;

        if (_selectedProduct is not null)
        {
            product.Id = _selectedProduct.Id;
            result = _stockServices.UpdateProductAsync(product).GetAwaiter().GetResult();
        }
        else
        {
            result = _stockServices.AddAProductAsync(product).GetAwaiter().GetResult();
        }

        if (result.IsSuccess)
        {
            MessageBox.Show(_selectedProduct is not null ? "Product updated successfully" : "Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearBtn_Click(sender, e);
            this.Close();
        }
        else
        {
            MessageBox.Show($"Operation failed: {result.Errors[0]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ProductNameTxt_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(ProductNameTxt.Text) && !string.IsNullOrWhiteSpace(ProductUniueIdentifierTxt.Text))
        {
            SaveBtn.Enabled = true;
        }
    }

    private void ProductUniueIdentifierTxt_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(ProductNameTxt.Text) && !string.IsNullOrWhiteSpace(ProductUniueIdentifierTxt.Text))
        {
            SaveBtn.Enabled = true;
        }
    }
}
