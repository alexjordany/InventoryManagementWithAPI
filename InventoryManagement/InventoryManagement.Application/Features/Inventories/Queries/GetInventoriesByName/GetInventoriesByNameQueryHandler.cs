namespace InventoryManagement.Application.Features.Inventories.Queries.GetInventoriesByName;

public class GetInventoriesByNameQueryHandler: IRequestHandler<GetInventoriesByNameQuery, List<InventoryByNameVM>>
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IMapper _mapper;

    public GetInventoriesByNameQueryHandler(IInventoryRepository inventoryRepository, IMapper mapper)
    {
        _inventoryRepository = inventoryRepository;
        _mapper = mapper;
    }

    public async Task<List<InventoryByNameVM>> Handle(GetInventoriesByNameQuery request, CancellationToken cancellationToken)
    {
        var getByName = await _inventoryRepository.GetInventoriesByName(request.Name);
        return _mapper.Map<List<InventoryByNameVM>>(getByName);
    }
}

