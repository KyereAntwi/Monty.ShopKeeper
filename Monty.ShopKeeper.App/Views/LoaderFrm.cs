using Monty.ShopKeeper.App.Services;
using Monty.ShopKeeper.App.Utils;

namespace Monty.ShopKeeper.App.Views;

public partial class LoaderFrm : Form
{
    private readonly IStockServices _stockServices;
    private ExportType _exportType;

    public LoaderFrm(string message, ExportType exportType, IStockServices stockServices)
    {
        InitializeComponent();
        MessageLb.Text = message;
        _stockServices = stockServices;
        _exportType = exportType;
    }

    private void MessageLb_Click(object sender, EventArgs e)
    {
    }

    private async void LoaderFrm_Load(object sender, EventArgs e)
    {
        try
        {
            switch (_exportType)
            {
                case ExportType.ExportProducts:
                    await _stockServices.ExportProductsIntoCsvAsync();
                    break;

                case ExportType.ExportSales:
                    await _stockServices.ExportSalesIntoCsvAsync();
                    break;

                case ExportType.ExportOverviewSummary:
                    await _stockServices.ExportOverviewSummaryIntoCsvAsync();
                    break;

                default:
                    throw new InvalidOperationException("Unsupported export type.");
            }

            MessageBox.Show("Products exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while exporting products: {ex.Message}", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            this.Close();
        }
    }
}
