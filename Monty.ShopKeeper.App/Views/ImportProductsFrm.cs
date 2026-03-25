using Monty.ShopKeeper.App.Services;

namespace Monty.ShopKeeper.App.Views;

public partial class ImportProductsFrm : Form
{
    private readonly IStockServices _stockServices;

    public ImportProductsFrm(IStockServices stockServices)
    {
        InitializeComponent();

        _stockServices = stockServices;
    }

    private async void UploadBtn_Click(object sender, EventArgs e)
    {
        // open file dialog to select the file
        OpenFileDialog openFileDialog = new()
        {
            // accept excel or csv files
            Filter = "Excel Files|*.xlsx;*.xls|CSV Files|*.csv"
        };

        if (openFileDialog.ShowDialog() != DialogResult.OK)
            return;

        string filePath = openFileDialog.FileName;
        try
        {
            // call the service to import products from the selected file
            var result = await _stockServices.ImportProductsFromFile(filePath);
            
            if(result.IsFailed)
            {
                MessageBox.Show($"Failed to import products: {string.Join(", ", result.Errors.Select(e => e.Message))}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Products imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while importing products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
