using PAW3.Data.Models;
using PAW3.Data.Tarea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Data.Repositories
{
    public interface IRepositoryPerson
    {
        Task<bool> UpsertAsync(Person entity, bool isUpdating);
        Task<bool> CreateAsync(Person entity);
        Task<bool> DeleteAsync(Person entity);
        Task<IEnumerable<Person>> ReadAsync();
        Task<Person> FindAsync(int id);
        Task<bool> UpdateAsync(Person entity);
        Task<bool> UpdateManyAsync(IEnumerable<Person> entities);
        Task<bool> ExistsAsync(Person entity);
    }

    public class RepositoryPerson : RepositoryBase<Person> ,IRepositoryPerson
    {

    }
}
