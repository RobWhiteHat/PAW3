using Microsoft.AspNetCore.Mvc;
using PAW3.Architecture;
using PAW3.Architecture.Providers;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Services.Contracts;

namespace PAW3.ServiceLocator.Services;

public interface INotificationService
{
    Task<IEnumerable<NotificationDTO>> GetDataAsync();
}

public class NotificationService(IRestProvider restProvider, IConfiguration configuration) : IService<NotificationDTO>, INotificationService
{
    public Task<IActionResult> CreateDataAsync(NotificationDTO obj)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteDataAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<NotificationDTO>> GetDataAsync()
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Notification");
        var response = await restProvider.GetAsync(url, null);
        return await JsonProvider.DeserializeAsync<IEnumerable<NotificationDTO>>(response);
    }

    public Task<NotificationDTO> GetDataByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PutDataAsync(string id, NotificationDTO obj)
    {
        throw new NotImplementedException();
    }

    Task<bool> IService<NotificationDTO>.CreateDataAsync(NotificationDTO obj)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<NotificationDTO>> IService<NotificationDTO>.GetDataAsync()
    {
        throw new NotImplementedException();
    }
}
