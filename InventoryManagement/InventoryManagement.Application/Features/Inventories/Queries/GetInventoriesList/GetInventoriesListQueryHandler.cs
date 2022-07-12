namespace InventoryManagement.Application.Features.Inventories.Queries.GetInventoriesList
{
    public class GetInventoriesListQueryHandler : IRequestHandler<GetInventoriesListQuery, List<InventoryListVM>>
    {
        private readonly IAsyncRepository<Inventory> _inventoryRepository;
        private readonly IMapper _mapper;

        public GetInventoriesListQueryHandler(IAsyncRepository<Inventory> inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<List<InventoryListVM>> Handle(GetInventoriesListQuery request, CancellationToken cancellationToken)
        {
            var allInventories = (await _inventoryRepository.ListAllAsync()).OrderBy(x => x.InventoryName);
            return _mapper.Map<List<InventoryListVM>>(allInventories);
        }
    }
}

