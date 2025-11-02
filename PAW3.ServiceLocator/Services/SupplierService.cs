using Microsoft.AspNetCore.Mvc;
using PAW3.Architecture;
using PAW3.Architecture.Providers;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Services.Contracts;

namespace PAW3.ServiceLocator.Services;

public interface ISupplierService
{
    Task<IEnumerable<SupplierDTO>> GetDataAsync();

}

public class SupplierService(IRestProvider restProvider, IConfiguration configuration) : IService<SupplierDTO>, ISupplierService
{
    public Task<bool> DeleteDataAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<SupplierDTO>> GetDataAsync()
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Supplier");
        var response = await restProvider.GetAsync(url, null);
        return await JsonProvider.DeserializeAsync<IEnumerable<SupplierDTO>>(response);
    }

    public Task<SupplierDTO> GetDataByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PutDataAsync(string id, SupplierDTO obj)
    {
        throw new NotImplementedException();
    }

    Task<bool> IService<SupplierDTO>.CreateDataAsync(SupplierDTO obj)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<SupplierDTO>> IService<SupplierDTO>.GetDataAsync()
    {
        throw new NotImplementedException();
    }
}
