using PAW3.Data.Models;
using PAW3.Data.Repositories;

namespace PAW3.Core.BusinessLogic
{
    public interface ISupplierBusiness
    {
        /// <summary>
        /// Saves the supplier item. If the item already exists, it updates it; otherwise, it creates a new item.
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        Task<bool> SaveSupplierAsync(Supplier supplier);

        /// <summary>
        /// Update the supplier
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        Task<bool> UpdateSupplierAsync(Supplier supplier);

        /// <summary>
        /// Deletes the supplier item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteSupplierAsync(int id);

        /// <summary>
        /// Gets the supplier items. If an ID is provided, retrieves the specific supplier item; otherwise, retrieves all supplier items.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Supplier>> GetSuppliers();

        /// <summary>
        /// Gets the supplier item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Supplier> GetSupplier(int id);
    }

    public class SupplierBusiness(IRepositorySupplier repoSupplier) : ISupplierBusiness
    {
        /// </inheritdoc>
        public async Task<bool> SaveSupplierAsync(Supplier supplier)
        {
            //Business logic here
            return await repoSupplier.UpsertAsync(supplier, false);
        }

        /// </inheritdoc>
        public async Task<bool> UpdateSupplierAsync(Supplier supplier)
        {
            //Business logic here
            return await repoSupplier.UpsertAsync(supplier, true);
        }

        /// </inheritdoc>
        public async Task<bool> DeleteSupplierAsync(int id)
        {
            //Business logic here
            var supplier = await repoSupplier.FindAsync(id);
            return await repoSupplier.DeleteAsync(supplier);
        }

        /// </inheritdoc>
        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            //Business logic here
            return await repoSupplier.ReadAsync();
        }

        /// </inheritdoc
        public async Task<Supplier> GetSupplier(int id)
        {
            //Business logic here
            return await repoSupplier.FindAsync(id);
        }
    }
}
