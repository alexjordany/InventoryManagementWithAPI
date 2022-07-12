namespace InventoryManagement.Application.Features.Inventories.Queries.GetInventoriesByName;

public class GetInventoriesByNameQuery :IRequest<List<InventoryByNameVM>>
{
    public string Name { get; set; } = string.Empty;
}

