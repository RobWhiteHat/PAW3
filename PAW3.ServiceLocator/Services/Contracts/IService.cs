using Microsoft.AspNetCore.Mvc;

namespace PAW3.ServiceLocator.Services.Contracts;

public interface IService<T> where T : class
{
    Task<IEnumerable<T>> GetDataAsync();
    Task<T> GetDataByIdAsync(string id);
    Task<bool> CreateDataAsync(T obj);
    Task<bool> DeleteDataAsync(string id);
    Task<bool> PutDataAsync(string id, T obj);

}
