using Monty.ShopKeeper.App.Entities;
using OfficeOpenXml;

namespace Monty.ShopKeeper.App.Utils;

public static class FileHelper
{
    public static async Task<IEnumerable<Product>> GetProductsFromFile(string filePath)
    {
        if (filePath.EndsWith(".xlsx") || filePath.EndsWith(".xls"))
        {
            return await GetProductsFromExcel(filePath);
        }
        else if (filePath.EndsWith(".csv"))
        {
            return await GetProductsFromCsv(filePath);
        }
        else
        {
            throw new InvalidOperationException("Unsupported file format. Please upload an Excel or CSV file.");
        }
    }

    private static async Task<IEnumerable<Product>> GetProductsFromExcel(string filePath)
    {
        ExcelPackage.License.SetNonCommercialPersonal("Monty.ShopKeeper");

        var products = new List<Product>();

        using var package = new ExcelPackage(new FileInfo(filePath));
        await package.LoadAsync(new FileStream(filePath, FileMode.Open, FileAccess.Read));

        var worksheet = package.Workbook.Worksheets[0];

        if(worksheet == null || worksheet?.Dimension.Rows == 0)
            throw new InvalidOperationException("The Excel file does not contain any worksheets or rows.");

        var rowCount = worksheet!.Dimension.Rows;

        for (int row = 2; row <= rowCount; row++)
        {
            var uniqueIdentifier = worksheet.Cells[row, 1].Text.Trim();
            var productName = worksheet.Cells[row, 2].Text.Trim();

            // validation for required fields
            if(string.IsNullOrEmpty(uniqueIdentifier) || string.IsNullOrEmpty(productName))
            {
                continue;
            }


            var product = new Product
            {
                UniqueIdentifier = uniqueIdentifier,
                Name = productName,
                Description = worksheet.Cells[row, 3].Text.Trim(),
                Image = string.IsNullOrWhiteSpace(worksheet.Cells[row, 4].Text)
                    ? null
                    : Convert.FromBase64String(worksheet.Cells[row, 4].Text.Trim()),
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System"
            };

            products.Add(product);
        }

        return products;
    }

    private static async Task<IEnumerable<Product>> GetProductsFromCsv(string filePath)
    {
        var products = new List<Product>();

        using var reader = new StreamReader(filePath);
        using var csv = new CsvHelper.CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);

        await foreach (var record in csv.GetRecordsAsync<Product>())
        {
            record.CreatedAt = DateTime.UtcNow;
            record.CreatedBy = "System";
            products.Add(record);
        }

        return products;
    }
}
