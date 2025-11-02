using Microsoft.AspNetCore.Mvc;
using PAW3.Architecture.Providers;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Helper;
using PAW3.ServiceLocator.Services;
using System.Text.Json;

namespace PAW3.ServiceLocator.Controllers;

public class ServiceControllerBase : ControllerBase
{
    protected readonly Dictionary<string, Func<Task<IEnumerable<object>>>> ServiceResolvers;
    protected readonly Dictionary<string, Func<object, Task<object>>> PostResolvers;


    protected ServiceControllerBase(IServiceMapper serviceMapper, ICategoryService categoryService)
    {
        //ServiceResolvers = new()
        //{
        //    ["product"] = async () =>
        //    {
        //        // defer resolution until invocation time
        //        var service = await serviceMapper.GetServiceAsync<ProductDTO>("product");
        //        var data = await service.GetDataAsync();
        //        return data.Cast<object>();
        //    },
        //    ["product"] = async () =>
        //    {
        //        // defer resolution until invocation time
        //        var service = await serviceMapper.GetServiceAsync<ProductDTO>("product");
        //        var data = await service.GetDataAsync();
        //        return data.Cast<object>();
        //    },

        //    ["inventory"] = async () =>
        //    {
        //        // defer resolution until invocation time
        //        var service = await serviceMapper.GetServiceAsync<InventoryDTO>("inventory");
        //        var data = await service.GetDataAsync();
        //        return data.Cast<object>();
        //    },

        //    ["category"] = async () =>
        //    {
        //        // defer resolution until invocation time
        //        var service = await serviceMapper.GetServiceAsync<CategoryDTO>("category");
        //        var data = await service.GetDataAsync();
        //        return data.Cast<object>();
        //    },

        //    ["component"] = async () =>
        //    {
        //        // defer resolution until invocation time
        //        var service = await serviceMapper.GetServiceAsync<ComponentDTO>("component");
        //        var data = await service.GetDataAsync();
        //        return data.Cast<object>();
        //    },

        //    ["notification"] = async () =>
        //    {
        //        // defer resolution until invocation time
        //        var service = await serviceMapper.GetServiceAsync<NotificationDTO>("notification");
        //        var data = await service.GetDataAsync();
        //        return data.Cast<object>();
        //    },

        //    ["role"] = async () =>
        //    {
        //        // defer resolution until invocation time
        //        var service = await serviceMapper.GetServiceAsync<RoleDTO>("role");
        //        var data = await service.GetDataAsync();
        //        return data.Cast<object>();
        //    },

        //    ["supplier"] = async () =>
        //    {
        //        // defer resolution until invocation time
        //        var service = await serviceMapper.GetServiceAsync<SupplierDTO>("supplier");
        //        var data = await service.GetDataAsync();
        //        return data.Cast<object>();
        //    },


        //    // Example for another service:
        //    // ["category"] = async () =>
        //    // {
        //    //     var service = await serviceMapper.GetServiceAsync<CategoryDTO>("category");
        //    //     var data = await service.GetDataAsync();
        //    //     return data.Cast<object>();
        //    // }
        //};

        //PostResolvers = new()
        //{
        //    ["category"] = async (payload) =>
        //    {
        //        //var service = await serviceMapper.GetServiceAsync<ProductDTO>("product");

        //        if (payload is not string category)
        //            throw new ArgumentException("Payload inválido para CategoryDTO");


        //        // Usar el método PostDataAsync de ProductService
        //        var result = await categoryService.CreateDataAsync(category);
        //        return result; // Puede ser IActionResult o algún objeto
        //    }
        //};
    }
}
