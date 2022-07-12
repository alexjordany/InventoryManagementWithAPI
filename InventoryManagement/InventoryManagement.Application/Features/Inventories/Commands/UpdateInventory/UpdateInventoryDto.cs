namespace InventoryManagement.Application.Features.Inventories.Commands.UpdateInventory;

public record class UpdateInventoryDto (int InventoryId, string InventoryName, int Quantity, double Price, DateTime LastModifiedDate);