using PAW3.Data.Models;
using PAW3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Core.BusinessLogic
{
    public interface ICategoryBusiness
    {
        /// <summary>
        /// Saves the category item. If the item already exists, it updates it; otherwise, it creates a new item.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<bool> SaveCategoryAsync(Category category);

        /// <summary>
        /// Deletes the category item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteCategoryAsync(int id);

        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Category>> GetCategories();

        /// <summary>
        /// Gets the category item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Category> GetCategory(int id);
    }

    public class CategoryBusiness(IRepositoryCategory repoCategory) : ICategoryBusiness
    {
        /// </inheritdoc>
        public async Task<bool> SaveCategoryAsync(Category category)
        {
            //Business logic here
            return await repoCategory.UpdateAsync(category);
        }

        /// </inheritdoc>
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            //Business logic here
            var category = await repoCategory.FindAsync(id);
            return await repoCategory.DeleteAsync(category);
        }

        /// </inheritdoc>
        public async Task<IEnumerable<Category>> GetCategories()
        {
            //Business logic here
            return await repoCategory.ReadAsync();
        }

        /// </inheritdoc
        public async Task<Category> GetCategory(int id)
        {
            //Business logic here
            return await repoCategory.FindAsync(id);
        }
    }
}

