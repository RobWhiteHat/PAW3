using PAW3.Data.Models;
using PAW3.Data.Repositories;

namespace PAW3.Core.BusinessLogic
{
    public interface IUserActionBusiness
    {
        /// <summary>
        /// Saves the user action item. If the item already exists, it updates it; otherwise, it creates a new item.
        /// </summary>
        /// <param name="userAction"></param>
        /// <returns></returns>
        Task<bool> SaveUserActionAsync(UserAction userAction);

        /// <summary>
        /// Update the user action
        /// </summary>
        /// <param name="userAction"></param>
        /// <returns></returns>
        Task<bool> UpdateUserActionAsync(UserAction userAction);

        /// <summary>
        /// Deletes the user action item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteUserActionAsync(int id);

        /// <summary>
        /// Gets the user action items. If an ID is provided, retrieves the specific user action item; otherwise, retrieves all userAction items.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<UserAction>> GetUserActions();

        /// <summary>
        /// Gets the user action item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserAction> GetUserAction(int id);
    }

    public class UserActionBusiness(IRepositoryUserAction repoUserAction) : IUserActionBusiness
    {
        /// </inheritdoc>
        public async Task<bool> SaveUserActionAsync(UserAction userAction)
        {
            //Business logic here
            return await repoUserAction.UpsertAsync(userAction, false);
        }

        /// </inheritdoc>
        public async Task<bool> UpdateUserActionAsync(UserAction userAction)
        {
            //Business logic here
            return await repoUserAction.UpsertAsync(userAction, true);
        }

        /// </inheritdoc>
        public async Task<bool> DeleteUserActionAsync(int id)
        {
            //Business logic here
            var userAction = await repoUserAction.FindAsync(id);
            return await repoUserAction.DeleteAsync(userAction);
        }

        /// </inheritdoc>
        public async Task<IEnumerable<UserAction>> GetUserActions()
        {
            //Business logic here
            return await repoUserAction.ReadAsync();
        }

        /// </inheritdoc
        public async Task<UserAction> GetUserAction(int id)
        {
            //Business logic here
            return await repoUserAction.FindAsync(id);
        }
    }
}
