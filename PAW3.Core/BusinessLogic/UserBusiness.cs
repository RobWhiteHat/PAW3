using PAW3.Data.Models;
using PAW3.Data.Repositories;

namespace PAW3.Core.BusinessLogic
{
    public interface IUserBusiness
    {
        /// <summary>
        /// Saves the user item. If the item already exists, it updates it; otherwise, it creates a new item.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> SaveUserAsync(User user);

        /// <summary>
        /// Update the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> UpdateUserAsync(User user);

        /// <summary>
        /// Deletes the user item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteUserAsync(int id);

        /// <summary>
        /// Gets the user items. If an ID is provided, retrieves the specific user item; otherwise, retrieves all user items.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<User>> GetUsers();

        /// <summary>
        /// Gets the user item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetUser(int id);
    }

    public class UserBusiness(IRepositoryUser repoUser) : IUserBusiness
    {
        /// </inheritdoc>
        public async Task<bool> SaveUserAsync(User user)
        {
            //Business logic here
            return await repoUser.UpsertAsync(user, false);
        }

        /// </inheritdoc>
        public async Task<bool> UpdateUserAsync(User user)
        {
            //Business logic here
            return await repoUser.UpsertAsync(user, true);
        }

        /// </inheritdoc>
        public async Task<bool> DeleteUserAsync(int id)
        {
            //Business logic here
            var user = await repoUser.FindAsync(id);
            return await repoUser.DeleteAsync(user);
        }

        /// </inheritdoc>
        public async Task<IEnumerable<User>> GetUsers()
        {
            //Business logic here
            return await repoUser.ReadAsync();
        }

        /// </inheritdoc
        public async Task<User> GetUser(int id)
        {
            //Business logic here
            return await repoUser.FindAsync(id);
        }
    }
}
