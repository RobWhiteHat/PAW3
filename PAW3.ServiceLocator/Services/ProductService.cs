using PAW3.Architecture;
using PAW3.Architecture.Providers;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Services.Contracts;

namespace PAW3.ServiceLocator.Services;

public interface IProductService
{
    Task<bool> CreateDataAsync(ProductDTO dto);
    Task<bool> DeleteDataAsync(string id);
    Task<IEnumerable<ProductDTO>> GetDataAsync();
    Task<ProductDTO> GetDataByIdAsync(string id);
    Task<bool> PutDataAsync(string id, ProductDTO dto);
}

public class ProductService(IRestProvider restProvider, IConfiguration configuration) : IService<ProductDTO>, IProductService
{
    public async Task<IEnumerable<ProductDTO>> GetDataAsync() //SE TRABAJA CON MINIMAL API
    {
        var url = configuration.GetStringFromAppSettings("MINIMAL", "Product");
        var response = await restProvider.GetAsync(url, null);
        return await JsonProvider.DeserializeAsync<IEnumerable<ProductDTO>>(response);
    }
    public async Task<ProductDTO> GetDataByIdAsync(string id) //SE TRABAJA CON MINIMAL API
    {
        var url = configuration.GetStringFromAppSettings("MINIMAL", "Product");
        var response = await restProvider.GetAsync(url, id);
        return await JsonProvider.DeserializeAsync<ProductDTO>(response);
    }

    public async Task<bool> CreateDataAsync(ProductDTO dto)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Product");
        var response = await restProvider.PostAsync(url, JsonProvider.Serialize(dto));
        return response.Contains("created", StringComparison.OrdinalIgnoreCase);
    }

    public async Task<bool> DeleteDataAsync(string id)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Product");
        var response = await restProvider.DeleteAsync(url, id);
        return response.Contains("OK", StringComparison.OrdinalIgnoreCase);
    }

    public async Task<bool> PutDataAsync(string id, ProductDTO dto)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Product");
        var response = await restProvider.PutAsync(url, id, JsonProvider.Serialize(dto));
        return response.Contains("OK", StringComparison.OrdinalIgnoreCase);
    }
}
