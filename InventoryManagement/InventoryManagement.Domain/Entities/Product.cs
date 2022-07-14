using InventoryManagement.Domain.Shared;

namespace InventoryManagement.Domain.Entities;

public class Product : AuditableEntity
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public double Price { get; set; }
}

