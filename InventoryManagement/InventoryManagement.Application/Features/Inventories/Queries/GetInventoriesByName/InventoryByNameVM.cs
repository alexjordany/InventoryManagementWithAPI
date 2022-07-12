namespace InventoryManagement.Application.Features.Inventories.Queries.GetInventoriesByName;

public record class InventoryByNameVM (int InventoryId, string InventoryName, int Quantity, double Price);