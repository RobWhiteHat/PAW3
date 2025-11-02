using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Services.Contracts;

namespace PAW3.ServiceLocator.Helper;

public interface IServiceMapper
{
    //Task<IService<T>> GetServiceAsync<T>(string name); 
}

public class ServiceMapper : IServiceMapper
{
    //private readonly IServiceProvider serviceProvider;

    //public ServiceMapper(IServiceProvider serviceProvider) => this.serviceProvider = serviceProvider;

    //public Task<IService<T>> GetServiceAsync<T>(string name)
    //{
    //    var service = name.ToLower() switch
    //    {
    //        "product" => (IService<T>)serviceProvider.GetRequiredService<IService<ProductDTO>>(),
    //        "inventory" => (IService<T>)serviceProvider.GetRequiredService<IService<InventoryDTO>>(),
    //        "category" => (IService<T>)serviceProvider.GetRequiredService<IService<CategoryDTO>>(),
    //        "component" => (IService<T>)serviceProvider.GetRequiredService<IService<ComponentDTO>>(),
    //        "notification" => (IService<T>)serviceProvider.GetRequiredService<IService<NotificationDTO>>(),
    //        "role" => (IService<T>)serviceProvider.GetRequiredService<IService<RoleDTO>>(),
    //        "supplier" => (IService<T>)serviceProvider.GetRequiredService<IService<SupplierDTO>>(),
    //        //"category" => (IService<T>)serviceProvider.GetRequiredService<IService<CategoryDTO>>(),  **EXAMPLE**
    //        _ => throw new ArgumentException($"Service not found for '{name}'")
    //    };

    //    return Task.FromResult(service);
    //}
}

