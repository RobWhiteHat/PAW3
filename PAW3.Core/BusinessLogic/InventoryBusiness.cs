using PAW3.Data.Models;
using PAW3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Core.BusinessLogic
{
    public interface IInventoryBusiness
    {
        /// <summary>
        /// Saves the inventory item. If the item already exists, it updates it; otherwise, it creates a new item.
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        Task<bool> SaveInventoryAsync(Inventory inventory);

        /// <summary>
        /// Update the inventory
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        Task<bool> UpdateInventoryAsync(Inventory inventory);

        /// <summary>
        /// Deletes the inventory item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteInventoryAsync(int id);

        /// <summary>
        /// Gets the inventory items. If an ID is provided, retrieves the specific inventory item; otherwise, retrieves all inventory items.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Inventory>> GetInventories();

        /// <summary>
        /// Gets the inventory item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Inventory> GetInventory(int id);
        
    }

    public class InventoryBusiness(IRepositoryInventory repoInventory) : IInventoryBusiness
    {
        /// </inheritdoc>
        public async Task<bool> SaveInventoryAsync(Inventory inventory)
        {
            //Business logic here
            return await repoInventory.UpsertAsync(inventory, false);
        }

        /// </inheritdoc>
        public async Task<bool> UpdateInventoryAsync(Inventory inventory)
        {
            //Business logic here
            return await repoInventory.UpsertAsync(inventory, true);
        }

        /// </inheritdoc>
        public async Task<bool> DeleteInventoryAsync(int id)
        {
            //Business logic here
            var inventory = await repoInventory.FindAsync(id);
            return await repoInventory.DeleteAsync(inventory);
        }

        /// </inheritdoc>
        public async Task<IEnumerable<Inventory>> GetInventories()
        {
            //Business logic here
            return await repoInventory.ReadAsync();
        }

        /// </inheritdoc
        public async Task<Inventory> GetInventory(int id)
        {
            //Business logic here
            return await repoInventory.FindAsync(id);
        }
    }
}

