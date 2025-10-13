using PAW3.Data.Models;
using PAW3.Data.Repositories;

namespace PAW3.Core.BusinessLogic
{
    public interface ITaskBusiness
    {
        /// <summary>
        /// Saves the task item. If the item already exists, it updates it; otherwise, it creates a new item.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<bool> SaveTaskAsync(Data.Models.Task task);

        /// <summary>
        /// Update the task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<bool> UpdateTaskAsync(Data.Models.Task task);

        /// <summary>
        /// Deletes the task item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteTaskAsync(int id);

        /// <summary>
        /// Gets the task items. If an ID is provided, retrieves the specific task item; otherwise, retrieves all task items.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Data.Models.Task>> GetTasks();

        /// <summary>
        /// Gets the task item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Data.Models.Task> GetTask(int id);
    }

    public class TaskBusiness(IRepositoryTask repoTask) : ITaskBusiness
    {
        /// </inheritdoc>
        public async Task<bool> SaveTaskAsync(Data.Models.Task task)
        {
            //Business logic here
            return await repoTask.UpsertAsync(task, false);
        }

        /// </inheritdoc>
        public async Task<bool> UpdateTaskAsync(Data.Models.Task task)
        {
            //Business logic here
            return await repoTask.UpsertAsync(task, true);
        }

        /// </inheritdoc>
        public async Task<bool> DeleteTaskAsync(int id)
        {
            //Business logic here
            var task = await repoTask.FindAsync(id);
            return await repoTask.DeleteAsync(task);
        }

        /// </inheritdoc>
        public async Task<IEnumerable<Data.Models.Task>> GetTasks()
        {
            //Business logic here
            return await repoTask.ReadAsync();
        }

        /// </inheritdoc
        public async Task<Data.Models.Task> GetTask(int id)
        {
            //Business logic here
            return await repoTask.FindAsync(id);
        }
    }
}
