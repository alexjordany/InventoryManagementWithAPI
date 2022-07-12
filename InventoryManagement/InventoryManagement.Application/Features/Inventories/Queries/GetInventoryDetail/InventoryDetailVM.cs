namespace InventoryManagement.Application.Features.Inventories.Queries.GetInventoryDetail;

public record class InventoryDetailVM(int InventoryId, string InventoryName, int Quantity, decimal Price, bool IsActive, DateTime CreatedDate);

