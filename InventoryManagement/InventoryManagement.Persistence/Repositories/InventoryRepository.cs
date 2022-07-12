using InventoryManagement.Application.Contracts;
using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Persistence.Repositories;

public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
{
    public InventoryRepository(InventoryManagementDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
    {
        var inventoriesbyName = await _dbContext.Inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        return inventoriesbyName;
    }
}

