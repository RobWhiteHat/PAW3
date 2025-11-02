using Microsoft.AspNetCore.Mvc;
using PAW3.Architecture;
using PAW3.Architecture.Providers;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Services.Contracts;

namespace PAW3.ServiceLocator.Services;

public interface IInventoryService
{
    Task<IEnumerable<InventoryDTO>> GetDataAsync();
    Task<bool> CreateDataAsync(InventoryDTO dto);
}

public class InventoryService(IRestProvider restProvider, IConfiguration configuration) : IService<InventoryDTO>, IInventoryService
{
    public async Task<IEnumerable<InventoryDTO>> GetDataAsync()
    {
        var url = configuration.GetStringFromAppSettings("MINIMAL", "Inventory");
        var response = await restProvider.GetAsync(url, null);
        return await JsonProvider.DeserializeAsync<IEnumerable<InventoryDTO>>(response);
    }

    public async Task<bool> CreateDataAsync(InventoryDTO dto)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Inventory");
        var response = await restProvider.PostAsync(url, JsonProvider.Serialize(dto));
        return response.Contains("OK", StringComparison.OrdinalIgnoreCase);
    }

    public Task<InventoryDTO> GetDataByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteDataAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PutDataAsync(string id, InventoryDTO obj)
    {
        throw new NotImplementedException();
    }
}
