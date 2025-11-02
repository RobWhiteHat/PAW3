using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.ServiceLocator.Services.Contracts;


namespace PAW3.Mvc.Controllers
{
    public class ProductDBController : Controller
    {
        private readonly ILogger<ProductDBController> _logger;
        private readonly IService<CategoryDTO> _service;
        public ProductDBController(ILogger<ProductDBController> logger, IService<CategoryDTO> service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Products()
        {
            var products = await _service.GetDataAsync<ProductDTO>("Product");
            var viewModel = new ProductDBViewModel()
            {
                Title = "Products",
                Products = products
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Inventories()
        {
            var inventories = await _serviceService.GetDataAsync<InventoryDTO>("Inventory");
            var products = await _serviceService.GetDataAsync<ProductDTO>("Product");
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
            var categories = await _serviceService.GetDataAsync<CategoryDTO>("Category");
            var viewModel = new ProductDBViewModel()
            {
                Title = "Categories",
                Categories = categories
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Components()
        {
            var components = await _serviceService.GetDataAsync<ComponentDTO>("Component");
            var viewModel = new ProductDBViewModel()
            {
                Title = "Components",
                Component = components
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Notifications()
        {
            var notifications = await _serviceService.GetDataAsync<NotificationDTO>("notification");
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
            var roles = await _serviceService.GetDataAsync<RoleDTO>("role");
            var viewModel = new ProductDBViewModel()
            {
                Title = "Roles",
                Role = roles
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Suppliers()
        {
            var supplier = await _serviceService.GetDataAsync<SupplierDTO>("supplier");
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
