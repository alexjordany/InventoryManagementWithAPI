using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Contracts;

public interface IInventoryRepository
{
    Task<IEnumerable<Inventory>> GetInventoriesByName(string name);
}

