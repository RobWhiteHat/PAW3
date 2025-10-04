using Microsoft.EntityFrameworkCore;
using PAW3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Data.Repositories;

public interface IRepositoryInventory
{
    Task<bool> UpsertAsync(Inventory entity, bool isUpdating);
    Task<bool> CreateAsync(Inventory entity);
    Task<bool> DeleteAsync(Inventory entity);
    Task<IEnumerable<Inventory>> ReadAsync();
    Task<Inventory> FindAsync(int id);
    Task<bool> UpdateAsync(Inventory entity);
    Task<bool> UpdateManyAsync(IEnumerable<Inventory> entities);
    Task<bool> ExistsAsync(Inventory entity);
}

public class RepositoryInventory : RepositoryBase<Inventory>, IRepositoryInventory
{
    public async new Task<bool> ExistsAsync(Product entity)
    {
        return await DbContext.Inventories.AnyAsync(x => x.InventoryId == entity.InventoryId);
    }
}

