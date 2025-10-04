using PAW3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAW3.Data.Repositories;

public interface IRepositoryTask
{
    Task<bool> UpsertAsync(Models.Task entity, bool isUpdating);
    Task<bool> CreateAsync(Models.Task entity);
    Task<bool> DeleteAsync(Models.Task entity);
    Task<IEnumerable<Models.Task>> ReadAsync();
    Task<Models.Task> FindAsync(int id);
    Task<bool> UpdateAsync(Models.Task entity);
    Task<bool> UpdateManyAsync(IEnumerable<Models.Task> entities);
    Task<bool> ExistsAsync(Models.Task entity);
}

public class RepositoryTask : RepositoryBase<Models.Task>, IRepositoryTask
{
}

