using InventoryManagement.Application.Exceptions;

namespace InventoryManagement.Application.Features.Inventories.Commands.UpdateInventory;

public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand, UpdateInventoryCommandResponse>
{
    private readonly IAsyncRepository<Inventory> _inventoryRepository;
    private readonly IMapper _mapper;

    public UpdateInventoryCommandHandler(IMapper mapper, IAsyncRepository<Inventory> inventoryRepository)
    {
        _mapper = mapper;
        _inventoryRepository = inventoryRepository;
    }

    public async Task<UpdateInventoryCommandResponse> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
    {
        var updateInventoryCommandResponse = new UpdateInventoryCommandResponse();
        var validator = new UpdateInventoryCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        var inventoryToUpdate = await _inventoryRepository.GetByIdAsync(request.InventoryId);

        if (inventoryToUpdate is null)
            throw new NotFoundException(nameof(Inventory), request.InventoryId);

        if (validationResult.Errors.Count > 0)
        {
            updateInventoryCommandResponse.Success = false;
            updateInventoryCommandResponse.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                updateInventoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        if (updateInventoryCommandResponse.Success)
        {
            request.LastModifiedDate = DateTime.Now;

            var inventory = _mapper.Map(request, inventoryToUpdate, typeof(UpdateInventoryCommand), typeof(Inventory));

            await _inventoryRepository.UpdateAsync(inventoryToUpdate);

            updateInventoryCommandResponse.Inventory = _mapper.Map<UpdateInventoryDto>(inventory);
        }
        return updateInventoryCommandResponse;

    }
}