namespace InventoryManagement.Application.Features.Inventories.Queries.GetInventoryDetail;

public class GetInventoryDetailQuery :IRequest<InventoryDetailVM>
{
    public int Id { get; set; }
}

