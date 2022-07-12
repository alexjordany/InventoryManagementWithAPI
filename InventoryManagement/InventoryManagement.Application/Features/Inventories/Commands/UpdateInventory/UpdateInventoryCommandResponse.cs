namespace InventoryManagement.Application.Features.Inventories.Commands.UpdateInventory;

public class UpdateInventoryCommandResponse : BaseResponse
{
    public UpdateInventoryCommandResponse(): base()
    {
    }

    public UpdateInventoryDto Inventory { get; set; }
}

