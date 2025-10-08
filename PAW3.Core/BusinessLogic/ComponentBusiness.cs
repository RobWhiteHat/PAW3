using PAW3.Data.Models;
using PAW3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Core.BusinessLogic
{
    public interface IComponentBusiness
    {
        /// <summary>
        /// Saves the component item. If the item already exists, it updates it; otherwise, it creates a new item.
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        Task<bool> SaveComponentAsync(Component component);

        /// <summary>
        /// Deletes the component item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteComponentAsync(int id);

        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Component>> GetComponents();

        /// <summary>
        /// Gets the component item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Component> GetComponent(int id);
    }

    public class ComponentBusiness(IRepositoryComponent repoComponent) : IComponentBusiness
    {
        /// </inheritdoc>
        public async Task<bool> SaveComponentAsync(Component component)
        {
            //Business logic here
            return await repoComponent.UpdateAsync(component);
        }

        /// </inheritdoc>
        public async Task<bool> DeleteComponentAsync(int id)
        {
            //Business logic here
            var component = await repoComponent.FindAsync(id);
            return await repoComponent.DeleteAsync(component);
        }

        /// </inheritdoc>
        public async Task<IEnumerable<Component>> GetComponents()
        {
            //Business logic here
            return await repoComponent.ReadAsync();
        }

        /// </inheritdoc
        public async Task<Component> GetComponent(int id)
        {
            //Business logic here
            return await repoComponent.FindAsync(id);
        }
    }
}

