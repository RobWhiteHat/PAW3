using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Services.Contracts;
using PAW3.ServiceLocator.Helper;
using System.Diagnostics;

namespace PAW3.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService<CategoryDTO> _serviceService;
        private readonly string createCategory = "~/Views/ProductDB/Category/CreateCategory.cshtml";

        public HomeController(ILogger<HomeController> logger, IService<CategoryDTO> serviceService)
        {
            _logger = logger;
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _serviceService.GetDataAsync();
            var homeViewModel = new HomeViewModel()
            {
                Categories = categories
            };
            return View(homeViewModel);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            // Si quisieras pasar datos iniciales al formulario, podrías hacerlo aquí.
            // Pero en este caso basta con devolver la vista vacía.
            return View(createCategory);

        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDTO model)
        {
            if (!ModelState.IsValid)
                return View(createCategory,model);

            var result = await _serviceService.CreateDataAsync(model);

            if (result)
            {
                TempData["Success"] = "Categoría creada exitosamente.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error al crear la categoría.");
            return View(createCategory,model);
        }






        //DEFAULT METHODS
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
