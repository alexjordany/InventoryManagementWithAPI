namespace InventoryManagement.Application.Features.Inventories.Commands.CreateInventory;

public class CreateInventoryCommandResponse : BaseResponse
{
    public CreateInventoryCommandResponse(): base()
    {
    }
    public CreateInventoryDto Inventory { get; set; }
}

