using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;
using System.Diagnostics;

namespace PAW3.Mvc.Controllers
{
    public class ProductDBController : Controller
    {
        private readonly ILogger<ProductDBController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public ProductDBController(ILogger<ProductDBController> logger, IServiceLocatorService serviceLocator, IServiceMapper serviceMapper)
        {
            _logger = logger;
            _serviceLocator = serviceLocator;
            _serviceMapper = serviceMapper;
        }

        public async Task<IActionResult> Products()
        {
            var products = await _serviceLocator.GetDataAsync<ProductDTO>("product");
            var viewModel = new ProductDBViewModel()
            {
                Title = "Products",
                Products = products
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Inventories()
        {
            var inventories = await _serviceLocator.GetDataAsync<InventoryDTO>("inventory");
            var products = await _serviceLocator.GetDataAsync<ProductDTO>("product");
            var viewModel = new ProductDBViewModel()
            {
                Title = "Inventory",
                Products = products,
                Inventory = inventories
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Categories()
        {
            var categories = await _serviceLocator.GetDataAsync<CategoryDTO>("category");
            var viewModel = new ProductDBViewModel()
            {
                Title = "Categories",
                Categories = categories
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Components()
        {
            var components = await _serviceLocator.GetDataAsync<ComponentDTO>("component");
            var viewModel = new ProductDBViewModel()
            {
                Title = "Components",
                Component = components
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Notifications()
        {
            var notifications = await _serviceLocator.GetDataAsync<NotificationDTO>("notification");
            var viewModel = new ProductDBViewModel()
            {
                Title = "Notifications",
                Notification = notifications
                //Users = users  **CUANDO SE IMPLEMENTE**
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Roles()
        {
            var roles = await _serviceLocator.GetDataAsync<RoleDTO>("role");
            var viewModel = new ProductDBViewModel()
            {
                Title = "Roles",
                Role = roles
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Suppliers()
        {
            var supplier = await _serviceLocator.GetDataAsync<SupplierDTO>("supplier");
            var viewModel = new ProductDBViewModel()
            {
                Title = "Suppliers",
                Supplier = supplier
            };
            return View(viewModel);
        }


        ///* **EXAMPLE** use to add more views...*/
        //public async Task<IActionResult> Categories()
        //{
        //    var categories = await _serviceLocator.GetDataAsync<InventoryDTO>("inventory");
        //    var ProductsDBViewModel = new ProductsDBViewModel()
        //    {
        //        Title = "Inventory",
        //        Inventory = categories
        //    };
        //    return View(ProductsDBViewModel);
        //}
    }
}
