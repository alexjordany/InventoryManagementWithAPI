namespace InventoryManagement.Application.Features.Inventories.Commands.UpdateInventory;

public class UpdateInventoryCommand : IRequest<UpdateInventoryCommandResponse>
{
    public int InventoryId { get; set; }
    public string InventoryName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public double Price { get; set; }
    public DateTime LastModifiedDate { get; set; }
}

