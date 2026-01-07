using FluentResults;
using Microsoft.EntityFrameworkCore;
using Monty.ShopKeeper.App.Data;
using Monty.ShopKeeper.App.Entities;
using Monty.ShopKeeper.App.Views.ViewModels;

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
            .AsSplitQuery()
            .Where(s => s.Product!.UniqueIdentifier.ToUpper() == productCode)
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
            .AsSplitQuery()
            .Where(s => s.Product!.UniqueIdentifier.ToUpper() == productCode)
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

        await dbContext.Baskets.AddAsync(basket, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }

    public async Task<Result<IEnumerable<Basket>>> GetAllSalesAsync(string productCode, DateTime fromDate, DateTime toDate, int page, int pageSize, CancellationToken cancellationToken = default)
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

        var baskets = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return baskets;
    }
}
