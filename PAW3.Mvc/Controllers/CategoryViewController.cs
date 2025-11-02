using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;
using PAW3.ServiceLocator.Services.Contracts;
using System.Diagnostics;
using System.Reflection;

namespace PAW3.Mvc.Controllers
{
    public class CategoryViewController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService<CategoryDTO> _service;
        private readonly string categoryIndex = "~/Views/ProductDB/Category/Categories.cshtml";
        private readonly string createCategory = "~/Views/ProductDB/Category/CreateCategory.cshtml";
        private readonly string editCategory = "~/Views/ProductDB/Category/EditCategory.cshtml";
        private readonly string deleteCategory = "~/Views/ProductDB/Category/DeleteCategory.cshtml";

        public CategoryViewController(ILogger<HomeController> logger, IService<CategoryDTO> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var categories = await _service.GetDataAsync();
            var viewModel = new ProductDBViewModel()
            {
                Title = "Categories",
                Categories = categories
            };
            return View(categoryIndex, viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Category(string id)
        {
            var categories = await _service.GetDataByIdAsync(id);
            var viewModel = new CategoryDTO()
            {
                CategoryId = categories.CategoryId,
                CategoryName = categories.CategoryName,
                Description = categories.Description
            };
            return View(categoryIndex, viewModel);
        }


        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View(createCategory);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDTO model)
        {
            if (!ModelState.IsValid)
                return View(createCategory, model);

            var result = await _service.CreateDataAsync(model);

            if (result)
            {
                TempData["Success"] = "Categoría creada exitosamente.";
                return RedirectToAction("Categories");
            }

            ModelState.AddModelError("", "Error al crear la categoría.");
            return View(createCategory, model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            bool result = await _service.DeleteDataAsync(id);

            if (!result)
            {
                TempData["Error"] = "Error al intentar eliminar la categoría.";
                return RedirectToAction("Categories");
            }
            TempData["Success"] = "Categoría eliminada exitosamente.";
            return RedirectToAction("Categories");
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(string id)
        {
            var category = await _service.GetDataByIdAsync(id);
            if (category == null)
            {
                TempData["Error"] = "Categoría no encontrada.";
                return RedirectToAction("Categories");
            }
            return View(editCategory, category);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(string id, CategoryDTO model)
        {
            if (!ModelState.IsValid)
                return View("EditCategory", model);

            bool result = await _service.PutDataAsync(id, model);

            if (!result)
            {
                ModelState.AddModelError("", "Error al actualizar la categoría.");
                return View("EditCategory", model);
            }

            TempData["Success"] = "Categoría actualizada exitosamente.";
            return RedirectToAction("Categories");
        }
    }
}
