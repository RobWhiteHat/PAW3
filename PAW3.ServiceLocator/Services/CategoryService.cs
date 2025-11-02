using Microsoft.AspNetCore.Mvc;
using PAW3.Architecture;
using PAW3.Architecture.Providers;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Services.Contracts;
using System.Text.Json;

namespace PAW3.ServiceLocator.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetDataAsync();
    Task<CategoryDTO> GetDataByIdAsync(string id);
    Task<bool> CreateDataAsync(CategoryDTO dto);
    Task<bool> DeleteDataAsync(string id);
    Task<bool> PutDataAsync(string id, CategoryDTO dto);

}

public class CategoryService(IRestProvider restProvider, IConfiguration configuration) : IService<CategoryDTO>, ICategoryService
{
    //SE TRABAJA CON MINIMAL API
    public async Task<IEnumerable<CategoryDTO>> GetDataAsync()
    {
        var url = configuration.GetStringFromAppSettings("MINIMAL", "Category");
        var response = await restProvider.GetAsync(url, null);
        return await JsonProvider.DeserializeAsync<IEnumerable<CategoryDTO>>(response);
    }
    public async Task<CategoryDTO> GetDataByIdAsync(string id)
    {
        var url = configuration.GetStringFromAppSettings("MINIMAL", "Category");
        var response = await restProvider.GetAsync(url, id);
        return await JsonProvider.DeserializeAsync<CategoryDTO>(response);
    }

    public async Task<bool> CreateDataAsync(CategoryDTO dto)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Category");
        var response = await restProvider.PostAsync(url, JsonProvider.Serialize(dto));
        return response.Contains("created", StringComparison.OrdinalIgnoreCase);
    }

    public async Task<bool> DeleteDataAsync(string id)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Category");
        var response = await restProvider.DeleteAsync(url, id);
        return response.Contains("OK", StringComparison.OrdinalIgnoreCase);
    }

    public async Task<bool> PutDataAsync(string id, CategoryDTO dto)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Category");
        var response = await restProvider.PutAsync(url, id, JsonProvider.Serialize(dto));
        return response.Contains("OK", StringComparison.OrdinalIgnoreCase);
    }

}
