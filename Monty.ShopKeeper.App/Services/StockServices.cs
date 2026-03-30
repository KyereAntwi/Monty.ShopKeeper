using FluentResults;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Monty.ShopKeeper.App.Data;
using Monty.ShopKeeper.App.Entities;
using Monty.ShopKeeper.App.Entities.Enums;
using Monty.ShopKeeper.App.Utils;
using Monty.ShopKeeper.App.Views.ViewModels;
using System.Data;

namespace Monty.ShopKeeper.App.Services;

public class StockServices(IShopKeeperDbContext dbContext) : IStockServices
{
    public async Task<Result> AddAProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        var existingProduct = await dbContext
            .Products
            .Where(p => p.UniqueIdentifier == product.UniqueIdentifier || p.Name == product.Name)
            .FirstOrDefaultAsync(cancellationToken);

        if(existingProduct is not null)
            return Result.Fail("A product with the same unique identifier or name already exists.");

        await dbContext.Products.AddAsync(product, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }

    public async Task<Result> DeleteProductAsync(int productId, CancellationToken cancellationToken = default)
    {
        var product = await dbContext.Products.FindAsync(productId, cancellationToken);

        if (product is null)
            return Result.Fail("Product not found.");

        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }

    public async Task<Result<IEnumerable<ProductDto>>> FilterProductsAsync(string uniqueIdentifier, string name, int storageId, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var query = dbContext
            .Products
            .Include(p => p.Stocks)
            .Include(p => p.ProductStoragePlaces)
            .AsSplitQuery()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(uniqueIdentifier))
        {
            query = query.Where(p => p.UniqueIdentifier.ToLower().Contains(uniqueIdentifier.ToLower()));
        }

        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(p => p.Name.ToLower().Contains(name.ToLower()));
        }

        if (storageId > 0)
        {
            query = query.Where(p => p.ProductStoragePlaces.Any(s => s.StoragePlaceId == storageId));
        }

        var products = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        var finalList = await products
            .Select(p => new ProductDto
            {
                Id = p.Id,
                UniqueIdentifier = p.UniqueIdentifier,
                Name = p.Name,
                Description = p.Description,
                Image = p.Image,
                CurrentSellingPrice = !p.Stocks.Any() ? 0 : p.Stocks.OrderBy(s => s.CreatedAt).LastOrDefault()!.UnitSellingPrice,
                CreatedAt = p.CreatedAt,
                StocksQuantity = p.Stocks.Count()
            }).ToListAsync(cancellationToken);

        return finalList;
    }

    public async Task<Result<IEnumerable<Stock>>> GetAllStocksForAProductAsync(string productCode, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var query = await dbContext
            .Stocks
            .Include(p => p.Product)
            .AsSplitQuery()
            .Where(s => s.Product!.UniqueIdentifier.ToUpper() == productCode)
            .ToListAsync(cancellationToken);

        return query;
    }

    public async Task<Result> StockProductAsync(string productCode, int quantity, decimal costPrice, decimal sellingPrice, CancellationToken cancellationToken = default)
    {
        var product = await dbContext
            .Products
            .Include(p => p.Stocks.OrderByDescending(s => s.CreatedAt).Take(1))
            .AsSplitQuery()
            .AsTracking()
            .Where(p => p.UniqueIdentifier.ToUpper() == productCode)
            .FirstOrDefaultAsync(cancellationToken);

        if (product is null)
        {
            return Result.Fail("Product does not exist");
        }

        var stock = new Stock
        {
            ProductId = product.Id,
            UnitCostPrice = costPrice,
            UnitSellingPrice = sellingPrice,
            Quantity = quantity
        };

        if (product.Stocks.Count > 0)
        {
            var lastStock = product.Stocks.First();
            stock.QuantityLeft = quantity + lastStock.QuantityLeft;
            lastStock.QuantityLeft = 0;
        }
        else
        {
            stock.QuantityLeft = quantity;
        }

        product.Stocks.Add(stock);
        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }

    public async Task<Result<decimal>> TotalSalesMadeOnProductAsync(string productCode, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default)
    {
        var query = dbContext
            .Sales
            .Include(s => s.Product)
            .Include(s => s.Basket)
            .AsSplitQuery()
            .Where(s => 
                s.Product!.UniqueIdentifier.ToUpper() == productCode &&
                !s.Basket!.Returned &&
                s.Basket.PurchaseType == PurchaseType.Debit
             )
            .AsQueryable();

        if (fromDate != DateTime.MinValue)
            query = query.Where(s => s.CreatedAt >= fromDate);

        if (toDate != DateTime.MinValue)
            query = query.Where(s => s.CreatedAt <= toDate);

        var totalSales = await query.SumAsync(s => (s.CurrentPricePaid), cancellationToken);

        return Result.Ok(totalSales);
    }

    public async Task<Result<int>> TotalUnitsSoldOnProductAsync(string productCode, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default)
    {
        var query = dbContext
            .Sales
            .Include(s => s.Product)
            .Include(s => s.Basket)
            .AsSplitQuery()
            .Where(s => s.Product!.UniqueIdentifier.ToUpper() == productCode && !s.Basket!.Returned)
            .AsQueryable();

        if (fromDate != DateTime.MinValue)
            query = query.Where(s => s.CreatedAt >= fromDate);

        if (toDate != DateTime.MinValue)
            query = query.Where(s => s.CreatedAt <= toDate);

        var totalUnitsSold = await query.SumAsync(s => s.Quantity, cancellationToken);

        return Result.Ok(totalUnitsSold);
    }

    public async Task<Result> UpdateProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        var existingProduct = await dbContext
            .Products
            .AsTracking()
            .Where(p => p.Id == product.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (existingProduct is null)
            return Result.Fail("Product not found.");

        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.UniqueIdentifier = product.UniqueIdentifier;
        existingProduct.Image = product.Image;

        await dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }

    public async Task<Result<IEnumerable<StoragePlace>>> GetAllStoragesAsync(CancellationToken cancellationToken = default)
    {
        var list = await dbContext
            .StoragePlaces
            .OrderByDescending(sp => sp.Order)
            .ToListAsync(cancellationToken);

        return list;
    }

    public async Task<Result> AddProductToStorageAsync(string productCode, int storagePlaceId, int quantity, CancellationToken cancellationToken = default)
    {
        var product = await dbContext
            .Products
            .Include(p => p.ProductStoragePlaces)
            .Include(p => p.Stocks.OrderByDescending(s => s.CreatedAt).Take(1))
            .AsSplitQuery()
            .AsTracking()
            .Where(p => p.UniqueIdentifier.ToUpper() == productCode)
            .FirstOrDefaultAsync(cancellationToken);

        if (product is null)
            return Result.Fail("Product does not exist");

        if (product.Stocks.Count <= 0)
            return Result.Fail("Product has no stocks available");

        if (product.Stocks.First().QuantityLeft <= 0)
            return Result.Fail("Product is out of stock");

        var existingProductStorage = product
            .ProductStoragePlaces
            .FirstOrDefault(psp => psp.StoragePlaceId == storagePlaceId);

        if (existingProductStorage is null)
        {
            var productStoragePlace = new ProductStoragePlace
            {
                ProductId = product.Id,
                StoragePlaceId = storagePlaceId,
                QuantiyOfProductInStorage = quantity
            };

            product.ProductStoragePlaces.Add(productStoragePlace);
        }
        else 
        {
            existingProductStorage.QuantiyOfProductInStorage += quantity;
        }

        product.Stocks.FirstOrDefault()!.QuantityLeft -= quantity;

        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }

    public async Task<Result> MakeASaleAsync(Basket basket, CancellationToken cancellationToken = default)
    {
        foreach(var item in basket.LineItems)
        {
            var product =  await dbContext
                .Products
                .Include(p => p.ProductStoragePlaces).ThenInclude(item => item.StoragePlace)
                .Include(p => p.Stocks.OrderByDescending(s => s.CreatedAt).Take(1))
                .Where(p => p.Id == item.ProductId)
                .AsSplitQuery()
                .AsTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (product is null)
                return Result.Fail($"Product with Id {item.ProductId} does not exist");

            if (product.ProductStoragePlaces.Count != 0)
            {
                var storagePlace = product
                    .ProductStoragePlaces
                    .OrderByDescending(psp => psp.StoragePlace!.Order)
                    .FirstOrDefault();

                if (storagePlace is null || storagePlace.QuantiyOfProductInStorage < item.Quantity)
                    return Result.Fail($"Insufficient stock in storage for product {product.Name}");

                storagePlace.QuantiyOfProductInStorage -= item.Quantity;
            }
            else
            {
                var stock = product.Stocks.FirstOrDefault();

                if (stock is null || stock.QuantityLeft < item.Quantity)
                    return Result.Fail($"Insufficient stock for product {product.Name}");

                stock.QuantityLeft -= item.Quantity;
            }

            dbContext.Products.Update(product);
            item.Product = null;
        }

        var loggedInUserUsername = await dbContext
            .LoggedInUser
            .Select(l => l.ApplicationUser!.UserName)
            .FirstOrDefaultAsync(cancellationToken);

        basket.CreatedBy = loggedInUserUsername ?? "System";

        await dbContext.Baskets.AddAsync(basket, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }

    public async Task<Result<IEnumerable<Basket>>> GetAllSalesAsync(
        string productCode, DateTime fromDate, DateTime toDate, int page, int pageSize, PurchaseType? purchaseType,
        bool returned, string? keyword, CancellationToken cancellationToken = default)
    {
        var query = dbContext
            .Baskets
            .Include(b => b.LineItems).ThenInclude(li => li.Product)
            .AsSplitQuery()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(productCode))
            query = query.Where(b => b.LineItems.Any(li => li.Product!.UniqueIdentifier.ToUpper() == productCode));

        if (fromDate != DateTime.MinValue)
            query = query.Where(b => b.CreatedAt.Date >= fromDate.Date);

        if (toDate != DateTime.MinValue)
            query = query.Where(b => b.CreatedAt.Date <= toDate.Date);

        if (purchaseType != null)
            query = query.Where(b => b.PurchaseType == purchaseType);

        if (returned)
            query = query.Where(b => b.Returned == returned);

        if (!string.IsNullOrEmpty(keyword))
            query = query.Where(b => b.Comments.ToLower().Contains(keyword.ToLower()));

        var baskets = await query
            .OrderByDescending(s => s.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return baskets;
    }

    public async Task<Result<bool>> AddProductsInBulkAsync(IEnumerable<Product> products, CancellationToken cancellationToken = default)
    {
        var productsList = products.ToList();

        // check to make sure product with same unique identifier or name are removed from the products list
        var existingProducts = await dbContext
            .Products
            .Where(p => 
                products.Select(prod => prod.UniqueIdentifier.ToLower()).Contains(p.UniqueIdentifier.ToLower()) ||
                products.Select(prod => prod.Name.ToLower()).Contains(p.Name.ToLower()))
            .ToListAsync(cancellationToken);

        productsList = [.. productsList.Where(p => 
            !existingProducts.Any(
                ep => ep.UniqueIdentifier.Equals(p.UniqueIdentifier, StringComparison.CurrentCultureIgnoreCase) || 
                ep.Name.Equals(p.Name, StringComparison.CurrentCultureIgnoreCase)))];

        if(productsList.Count == 0)
            return Result.Fail("No new products to add. All products in the list already exist.");

        var dbPath = Path.Combine(AppContext.BaseDirectory, "shopkeeper.db");
        string ConnectionString = $"Data Source={dbPath}";

        using (var connection = new SqliteConnection(ConnectionString))
        {
            await connection.OpenAsync(cancellationToken);

            using var transaction = await connection.BeginTransactionAsync(cancellationToken);
            using var command = connection.CreateCommand();

            command.CommandText = @"
            INSERT INTO Products (UniqueIdentifier, Name, Description, Image, CreatedAt, CreatedBy)
            VALUES ($uniqueIdentifier, $name, $description, $image, $createdAt, $createdBy);";

            var uniqueIdentifierParam = command.Parameters.Add("$uniqueIdentifier", SqliteType.Text);
            var nameParam = command.Parameters.Add("$name", SqliteType.Text);
            var descriptionParam = command.Parameters.Add("$description", SqliteType.Text);
            var imageParam = command.Parameters.Add("$image", SqliteType.Blob);
            var createdAtParam = command.Parameters.Add("$createdAt", SqliteType.Text);
            var createdByParam = command.Parameters.Add("$createdBy", SqliteType.Text);

            foreach (var product in productsList)
            {
                uniqueIdentifierParam.Value = product.UniqueIdentifier;
                nameParam.Value = product.Name;
                descriptionParam.Value = product.Description;
                imageParam.Value = product.Image ?? (object)DBNull.Value;
                createdAtParam.Value = DateTime.UtcNow.ToString("o");
                createdByParam.Value = product.CreatedBy;

                await command.ExecuteNonQueryAsync(cancellationToken);
            }

            await transaction.CommitAsync(cancellationToken);
        }

        return Result.Ok(true);
    }

    public async Task<Result<bool>> ImportProductsFromFile(string filePath)
    {
        var products = await FileHelper.GetProductsFromFile(filePath);
        return await AddProductsInBulkAsync(products);
    }

    public async Task ExportProductsIntoCsvAsync(CancellationToken cancellation = default)
    {
        var products = await dbContext
        .Products
        .Select(p => new
        {
            p.UniqueIdentifier,
            p.Name,
            CurrentSellingPrice = !p.Stocks.Any() ? 0m : p.Stocks.OrderBy(s => s.CreatedAt).LastOrDefault()!.UnitSellingPrice,
            StocksQuantity = p.Stocks.Count()
        })
        .ToListAsync(cancellation);

        if (products.Count == 0)
            return;

        // simple CSV escaping helper
        static string Escape(string? v)
        {
            if (string.IsNullOrEmpty(v)) return string.Empty;
            var s = v.Replace("\"", "\"\"");
            return (s.Contains(',') || s.Contains('"') || s.Contains('\n') || s.Contains('\r')) ? $"\"{s}\"" : s;
        }

        var csvLines = new List<string>
        {
            "Unique Identifier,Name,Current Selling Price,Stocks Quantity"
        };

        foreach (var line in products)
        {
            csvLines.Add(string.Join(",",
                Escape(line.UniqueIdentifier),
                Escape(line.Name),
                Escape($"GHC{line.CurrentSellingPrice:0.00}"),
                line.StocksQuantity.ToString()
            ));
        }

        var csvContent = string.Join(Environment.NewLine, csvLines);
        var exportFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"products_export_{DateTime.Now:yyyyMMddHHmmss}.csv");
        await File.WriteAllTextAsync(exportFilePath, csvContent, cancellation);
    }

    public async Task ExportSalesIntoCsvAsync(CancellationToken cancellation = default)
    {
        var sales = await dbContext
        .Sales
        .Include(s => s.Product)
        .AsSplitQuery()
        .Select(s => new
        {
            ProductUniqueIdentifier = s.Product!.UniqueIdentifier,
            ProductName = s.Product.Name,
            QuantitySold = s.Quantity,
            CurrentPricePaid = s.CurrentPricePaid,
            SaleDate = s.CreatedAt
        })
        .OrderByDescending(s => s.SaleDate)
        .ToListAsync(cancellation);

        if (sales.Count == 0)
            return;

        static string Escape(string? v)
        {
            if (string.IsNullOrEmpty(v)) return string.Empty;
            var s = v.Replace("\"", "\"\"");
            return (s.Contains(',') || s.Contains('"') || s.Contains('\n') || s.Contains('\r')) ? $"\"{s}\"" : s;
        }

        var csvLines = new List<string>
        {
            "Product Unique Identifier,Product Name,Quantity Sold,Current Price Paid,Sale Date"
        };

        foreach (var line in sales)
        {
            csvLines.Add(string.Join(",",
                Escape(line.ProductUniqueIdentifier),
                Escape(line.ProductName),
                line.QuantitySold.ToString(),
                Escape($"GHC{line.CurrentPricePaid:0.00}"),
                Escape(line.SaleDate.ToString("yyyy-MM-dd HH:mm:ss"))
            ));
        }

        var csvContent = string.Join(Environment.NewLine, csvLines);
        var exportFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"sales_export_{DateTime.Now:yyyyMMddHHmmss}.csv");
        await File.WriteAllTextAsync(exportFilePath, csvContent, cancellation);
    }

    public async Task ExportOverviewSummaryIntoCsvAsync(CancellationToken cancellation = default)
    {
        // report
        // 1. that contains the total sales made on each product and
        // 2. the total units sold for each product
        // 3. the total profit made on each product (total sales - total cost of stocks sold)
        // 4. the total quantity of stocks left for each product
        // 5. the total quantity of stocks left in each storage for each product
        // 6. the total stocks that have been stocked for each product
        // 7. the total amount spent on stocking each product (total cost price of stocks stocked)

        // Load products with stocks and storage places
        var products = await dbContext.Products
            .Include(p => p.Stocks)
            .Include(p => p.ProductStoragePlaces).ThenInclude(psp => psp.StoragePlace)
            .AsSplitQuery()
            .ToListAsync(cancellation);

        if (products.Count == 0)
            return;

        var productIds = products.Select(p => p.Id).ToList();

        // sales aggregates for all products in one query
        var salesAggregates = await dbContext.Sales
            .Where(s => productIds.Contains(s.ProductId))
            .GroupBy(s => s.ProductId)
            .Select(g => new
            {
                ProductId = g.Key,
                TotalUnitsSold = g.Sum(x => (int?)x.Quantity) ?? 0,
                TotalSalesAmount = g.Sum(x => (decimal?)x.CurrentPricePaid) ?? 0m
            })
            .ToDictionaryAsync(x => x.ProductId, cancellation);

        static string Escape(string? v)
        {
            if (string.IsNullOrEmpty(v)) return string.Empty;
            var s = v.Replace("\"", "\"\"");
            return (s.Contains(',') || s.Contains('"') || s.Contains('\n') || s.Contains('\r')) ? $"\"{s}\"" : s;
        }

        var csvLines = new List<string>
        {
            "Unique Identifier,Name,Total Sales,Total Units Sold,Total Stocking Cost,Total Stocked Quantity,Total Quantity Left,Storage Breakdown,Profit"
        };

        foreach (var p in products)
        {
            salesAggregates.TryGetValue(p.Id, out var sales);

            var totalUnitsSold = sales?.TotalUnitsSold ?? 0;
            var totalSalesAmount = sales?.TotalSalesAmount ?? 0m;

            var totalStockedQuantity = p.Stocks.Sum(s => s.Quantity);
            var totalStockingCost = p.Stocks.Sum(s => s.UnitCostPrice * s.Quantity);
            var totalQuantityLeftInStocks = p.Stocks.Sum(s => s.QuantityLeft);
            var totalQuantityLeftInStorages = p.ProductStoragePlaces.Sum(psp => psp.QuantiyOfProductInStorage);

            var totalQuantityLeft = totalQuantityLeftInStocks + totalQuantityLeftInStorages;

            var storageBreakdown = string.Join(";", p.ProductStoragePlaces
                .Select(psp => $"{(psp.StoragePlace?.Title ?? psp.StoragePlaceId.ToString())}:{psp.QuantiyOfProductInStorage}"));

            // weighted-average COGS estimate
            decimal costOfGoodsSold = 0m;
            if (totalStockedQuantity > 0)
            {
                var avgUnitCost = totalStockingCost / totalStockedQuantity;
                costOfGoodsSold = avgUnitCost * totalUnitsSold;
            }

            var profit = totalSalesAmount - costOfGoodsSold;

            csvLines.Add(
                string.Join(",",
                    Escape(p.UniqueIdentifier),
                    Escape(p.Name),
                    Escape($"GHC{totalSalesAmount:0.00}"),
                    totalUnitsSold.ToString(),
                    Escape($"GHC{totalStockingCost:0.00}"),
                    totalStockedQuantity.ToString(),
                    totalQuantityLeft.ToString(),
                    Escape(storageBreakdown),
                    Escape($"GHC{profit:0.00}")
                )
            );
        }

        var csvContent = string.Join(Environment.NewLine, csvLines);
        var exportFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"overview_export_{DateTime.Now:yyyyMMddHHmmss}.csv");
        await File.WriteAllTextAsync(exportFilePath, csvContent, cancellation);
    }

    public async Task<Result> MakeAReturnAsync(Basket basket, CancellationToken cancellationToken = default)
    {
        var existingBasket = await dbContext.Baskets
            .Include(b => b.LineItems).ThenInclude(li => li.Product)
            .AsSplitQuery()
            .Where(b => b.Id == basket.Id)
            .AsTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (existingBasket is null) return Result.Fail("Basket does not exist");

        existingBasket.Returned = true;

        // update stocks and storage quantities
        foreach (var item in existingBasket.LineItems)
        {
            var product = item.Product;
            if (product is null) continue;
            if (product.ProductStoragePlaces.Count != 0)
            {
                var storagePlace = product
                    .ProductStoragePlaces
                    .OrderByDescending(psp => psp.StoragePlace!.Order)
                    .FirstOrDefault();
                if (storagePlace is not null)
                {
                    storagePlace.QuantiyOfProductInStorage += item.Quantity;
                }
            }
            else
            {
                var stock = product.Stocks.FirstOrDefault();
                if (stock is not null)
                {
                    stock.QuantityLeft += item.Quantity;
                }
            }
            dbContext.Products.Update(product);
        }

        dbContext.Baskets.Update(existingBasket);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }

    public async Task<Result> CompleteACreditedSaleAsync(Basket basket, CancellationToken cancellationToken = default)
    {
        var existingBasket = await dbContext.Baskets.FindAsync(basket.Id, cancellationToken);

        if (existingBasket == null)
            return Result.Fail($"Basket with Id {basket.Id} does not exist");

        existingBasket.PurchaseType = PurchaseType.Debit;
        existingBasket.BalancePaid = basket.BalancePaid;
        existingBasket.TotalAmountPaid = basket.TotalAmountPaid;

        dbContext.Baskets.Update(existingBasket);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
