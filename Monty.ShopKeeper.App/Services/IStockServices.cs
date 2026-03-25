using FluentResults;
using Monty.ShopKeeper.App.Entities;
using Monty.ShopKeeper.App.Entities.Enums;
using Monty.ShopKeeper.App.Views.ViewModels;

namespace Monty.ShopKeeper.App.Services;

public interface IStockServices
{
    #region Products services
    Task<Result> AddAProductAsync(Product product, CancellationToken cancellationToken = default);
    Task<Result> UpdateProductAsync(Product product, CancellationToken cancellationToken = default);
    Task<Result> DeleteProductAsync(int productId, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<ProductDto>>> FilterProductsAsync(string uniqueIdentifier, string name, int storageId, int page, int pageSize, CancellationToken cancellationToken = default);
    Task<Result<bool>> AddProductsInBulkAsync(IEnumerable<Product> products, CancellationToken cancellationToken = default);
    #endregion

    #region Product stocking services
    Task<Result> StockProductAsync(string productCode, int quantity, decimal costPrice, decimal sellingPrice, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<Stock>>> GetAllStocksForAProductAsync(string productCode, int page, int pageSize, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<StoragePlace>>> GetAllStoragesAsync(CancellationToken cancellationToken = default);
    Task<Result> AddProductToStorageAsync(string productCode, int storagePlaceId, int quantity, CancellationToken cancellationToken = default);
    #endregion

    #region Sales services
    Task<Result> MakeASaleAsync(Basket basket, CancellationToken cancellationToken = default);
    Task<Result> MakeAReturnAsync(Basket basket, CancellationToken cancellationToken = default);
    Task<Result> CompleteACreditedSaleAsync(Basket basket, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<Basket>>> GetAllSalesAsync(
        string productCode,
        DateTime fromDate,
        DateTime toDate,
        int page,
        int pageSize,
        PurchaseType? purchaseType,
        bool returned,
        string? keyword,
        CancellationToken cancellationToken = default);
    #endregion

    #region Reports services
    Task<Result<decimal>> TotalSalesMadeOnProductAsync(string productCode, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default);
    Task<Result<int>> TotalUnitsSoldOnProductAsync(string productCode, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken = default);
    Task<Result<bool>> ImportProductsFromFile(string filePath);
    Task ExportProductsIntoCsvAsync(CancellationToken cancellation = default);
    Task ExportSalesIntoCsvAsync(CancellationToken cancellation = default);
    Task ExportOverviewSummaryIntoCsvAsync(CancellationToken cancellation = default);
    #endregion
}
