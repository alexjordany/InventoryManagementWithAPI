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
            //_mapper.Map(request, inventoryToUpdate, typeof(UpdateInventoryCommand), typeof(Inventory));

            //await _inventoryRepository.UpdateAsync(inventoryToUpdate);


            //updateInventoryCommandResponse.Inventory = _mapper.Map<UpdateInventoryDto>(inventoryToUpdate);
            request.LastModifiedDate = DateTime.Now;

            var inventory = _mapper.Map(request, inventoryToUpdate, typeof(UpdateInventoryCommand), typeof(Inventory));

            await _inventoryRepository.UpdateAsync(inventoryToUpdate);

            updateInventoryCommandResponse.Inventory = _mapper.Map<UpdateInventoryDto>(inventory);

        }
        return updateInventoryCommandResponse;

    }
}

//if (createInventoryCommandResponse.Success)
//        {
//            var inventory = new Inventory()
//            {
//                InventoryName = request.InventoryName,
//                Price = request.Price,
//                Quantity = request.Quantity,
//                Active = true,
//                CreatedDate = DateTime.Now
//            };

//inventory = await _inventoryRepository.AddAsync(inventory);
//createInventoryCommandResponse.Inventory = _mapper.Map<CreateInventoryDto>(inventory);
//        }

//        return createInventoryCommandResponse;
//    }
//}
