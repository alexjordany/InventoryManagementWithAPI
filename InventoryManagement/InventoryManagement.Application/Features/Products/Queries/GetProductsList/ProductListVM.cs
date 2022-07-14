namespace InventoryManagement.Application.Features.Products.Queries.GetProductsList;

public record class ProductListVM (int ProductId, string ProductName, int Quantity, double Price);
