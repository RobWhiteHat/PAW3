using Microsoft.AspNetCore.Mvc;
using PAW3.Architecture;
using PAW3.Architecture.Providers;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Services.Contracts;

namespace PAW3.ServiceLocator.Services;

public interface IComponentService
{
    Task<IEnumerable<ComponentDTO>> GetDataAsync();
    Task<IActionResult> CreateDataAsync<ComponentDTO>(ComponentDTO dto);
}

public class ComponentService(IRestProvider restProvider, IConfiguration configuration) : IService<ComponentDTO>, IComponentService
{
    public async Task<IEnumerable<ComponentDTO>> GetDataAsync()
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Component");
        var response = await restProvider.GetAsync(url, null);
        return await JsonProvider.DeserializeAsync<IEnumerable<ComponentDTO>>(response);
    }

    public async Task<IActionResult> CreateDataAsync<ComponentDTO>(ComponentDTO dto)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Component");
        var response = await restProvider.PostAsync(url, JsonProvider.Serialize(dto));
        return await JsonProvider.DeserializeAsync<IActionResult>(response);
    }

    Task<IEnumerable<ComponentDTO>> IService<ComponentDTO>.GetDataAsync()
    {
        throw new NotImplementedException();
    }

    Task<bool> IService<ComponentDTO>.CreateDataAsync(ComponentDTO obj)
    {
        throw new NotImplementedException();
    }

    public Task<ComponentDTO> GetDataByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteDataAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PutDataAsync(string id, ComponentDTO obj)
    {
        throw new NotImplementedException();
    }
}
