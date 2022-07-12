namespace InventoryManagement.Application.Features.Inventories.Commands.CreateInventory;

public class CreateInventoryCommand : IRequest<CreateInventoryCommandResponse>
{
    public string InventoryName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public double Price { get; set; }
}

