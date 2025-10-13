using PAW3.Data.Models;
using PAW3.Data.Repositories;

namespace PAW3.Core.BusinessLogic
{
    public interface INotificationBusiness
    {
        /// <summary>
        /// Saves the notification item. If the item already exists, it updates it; otherwise, it creates a new item.
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        Task<bool> SaveNotificationAsync(Notification notification);

        /// <summary>
        /// Update the notification
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        Task<bool> UpdateNotificationAsync(Notification notification);


        /// <summary>
        /// Deletes the inventory item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteNotificationAsync(int id);

        /// <summary>
        /// Get all notifications.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Notification>> GetNotifications();

        /// <summary>
        /// Gets the notification item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Notification> GetNotification(int id);
    }

    public class NotificationBusiness(IRepositoryNotification repoNotification) : INotificationBusiness
    {
        /// </inheritdoc>
        public async Task<bool> SaveNotificationAsync(Notification notification)
        {
            //Business logic here
            return await repoNotification.UpsertAsync(notification, false);
        }

        /// </inheritdoc>
        public async Task<bool> UpdateNotificationAsync(Notification notification)
        {
            //Business logic here
            return await repoNotification.UpsertAsync(notification, true);
        }

        /// </inheritdoc>
        public async Task<bool> DeleteNotificationAsync(int id)
        {
            //Business logic here
            var notification = await repoNotification.FindAsync(id);
            return await repoNotification.DeleteAsync(notification);
        }

        /// </inheritdoc>
        public async Task<IEnumerable<Notification>> GetNotifications()
        {
            //Business logic here
            return await repoNotification.ReadAsync();
        }

        /// </inheritdoc
        public async Task<Notification> GetNotification(int id)
        {
            //Business logic here
            return await repoNotification.FindAsync(id);
        }
    }
}

