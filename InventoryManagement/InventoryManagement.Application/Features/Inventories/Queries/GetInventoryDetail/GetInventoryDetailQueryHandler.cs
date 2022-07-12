namespace InventoryManagement.Application.Features.Inventories.Queries.GetInventoryDetail;

public class GetInventoryDetailQueryHandler : IRequestHandler<GetInventoryDetailQuery, InventoryDetailVM>
{
    private readonly IAsyncRepository<Inventory> _inventoryRepository;
    private readonly IMapper _mapper;

    public GetInventoryDetailQueryHandler(IAsyncRepository<Inventory> inventoryRepository, IMapper mapper)
    {
        _inventoryRepository = inventoryRepository;
        _mapper = mapper;
    }

    public async Task<InventoryDetailVM> Handle(GetInventoryDetailQuery request, CancellationToken cancellationToken)
    {
        var inventoryDetail = await _inventoryRepository.GetByIdAsync(request.Id);
        return _mapper.Map<InventoryDetailVM>(inventoryDetail);
    }
}

