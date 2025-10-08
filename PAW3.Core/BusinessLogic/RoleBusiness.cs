using PAW3.Data.Models;
using PAW3.Data.Repositories;

namespace PAW3.Core.BusinessLogic
{
    public interface IRoleBusiness
    {
        /// <summary>
        /// Saves the role item. If the item already exists, it updates it; otherwise, it creates a new item.
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        Task<bool> SaveRoleAsync(Role role);

        /// <summary>
        /// Deletes the inventory item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteRoleAsync(int id);

        /// <summary>
        /// Get all roles.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Role>> GetRoles();

        /// <summary>
        /// Gets the role item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Role> GetRole(int id);
    }

    public class RoleBusiness(IRepositoryRole repoRole) : IRoleBusiness
    {
        /// </inheritdoc>
        public async Task<bool> SaveRoleAsync(Role role)
        {
            //Business logic here
            return await repoRole.UpdateAsync(role);
        }

        /// </inheritdoc>
        public async Task<bool> DeleteRoleAsync(int id)
        {
            //Business logic here
            var role = await repoRole.FindAsync(id);
            return await repoRole.DeleteAsync(role);
        }

        /// </inheritdoc>
        public async Task<IEnumerable<Role>> GetRoles()
        {
            //Business logic here
            return await repoRole.ReadAsync();
        }

        /// </inheritdoc
        public async Task<Role> GetRole(int id)
        {
            //Business logic here
            return await repoRole.FindAsync(id);
        }
    }
}

