namespace InventoryManagement.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<CreateProductCommandResponse>
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public double Price { get; set; }

    public List<CreateProductInventoryDto>? ProductInventories { get; set; }
}

