namespace InventoryManagement.Application.Features.Inventories.Commands.CreateInventory;

public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, CreateInventoryCommandResponse>
{
    private readonly IAsyncRepository<Inventory> _inventoryRepository;
    private readonly IMapper _mapper;

    public CreateInventoryCommandHandler(IAsyncRepository<Inventory> inventoryRepository, IMapper mapper)
    {
        _inventoryRepository = inventoryRepository;
        _mapper = mapper;
    }

    public async Task<CreateInventoryCommandResponse> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
    {
        var createInventoryCommandResponse = new CreateInventoryCommandResponse();

        var validator = new CreateInventoryCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if(validationResult.Errors.Count > 0)
        {
            createInventoryCommandResponse.Success = false;
            createInventoryCommandResponse.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                createInventoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            }
        }
        if (createInventoryCommandResponse.Success)
        {
            var inventory = new Inventory()
            {
                InventoryName = request.InventoryName,
                Price = request.Price,
                Quantity = request.Quantity,
                Active = true,
                CreatedDate = DateTime.Now
            };

            inventory = await _inventoryRepository.AddAsync(inventory);
            createInventoryCommandResponse.Inventory = _mapper.Map<CreateInventoryDto>(inventory);
        }

        return createInventoryCommandResponse;
    }
}

