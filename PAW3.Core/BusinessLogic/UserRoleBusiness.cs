using PAW3.Data.Models;
using PAW3.Data.Repositories;

namespace PAW3.Core.BusinessLogic
{
    public interface IUserRoleBusiness
    {
        /// <summary>
        /// Saves the use role item. If the item already exists, it updates it; otherwise, it creates a new item.
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        Task<bool> SaveUserRoleAsync(UserRole userRole);

        /// <summary>
        /// Update the use role
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        Task<bool> UpdateUserRoleAsync(UserRole userRole);

        /// <summary>
        /// Deletes the use role item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteUserRoleAsync(int id);

        /// <summary>
        /// Gets the use role items. If an ID is provided, retrieves the specific userRole item; otherwise, retrieves all userRole items.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<UserRole>> GetUserRoles();

        /// <summary>
        /// Gets the use role item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserRole> GetUserRole(int id);
    }

    public class UserRoleBusiness(IRepositoryUserRole repoUserRole) : IUserRoleBusiness
    {
        /// </inheritdoc>
        public async Task<bool> SaveUserRoleAsync(UserRole userRole)
        {
            //Business logic here
            return await repoUserRole.UpsertAsync(userRole, false);
        }

        /// </inheritdoc>
        public async Task<bool> UpdateUserRoleAsync(UserRole userRole)
        {
            //Business logic here
            return await repoUserRole.UpsertAsync(userRole, true);
        }

        /// </inheritdoc>
        public async Task<bool> DeleteUserRoleAsync(int id)
        {
            //Business logic here
            var userRole = await repoUserRole.FindAsync(id);
            return await repoUserRole.DeleteAsync(userRole);
        }

        /// </inheritdoc>
        public async Task<IEnumerable<UserRole>> GetUserRoles()
        {
            //Business logic here
            return await repoUserRole.ReadAsync();
        }

        /// </inheritdoc
        public async Task<UserRole> GetUserRole(int id)
        {
            //Business logic here
            return await repoUserRole.FindAsync(id);
        }
    }
}
