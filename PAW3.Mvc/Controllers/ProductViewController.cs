using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;
using PAW3.ServiceLocator.Services.Contracts;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace PAW3.Mvc.Controllers
{
    public class ProductViewController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService<ProductDTO> _productService;
        private readonly IService<CategoryDTO> _categoryService;
        private readonly string productIndex = "~/Views/ProductDB/Product/Products.cshtml";
        private readonly string createProduct = "~/Views/ProductDB/Product/CreateProduct.cshtml";
        private readonly string editProduct = "~/Views/ProductDB/Product/EditProduct.cshtml";

        public ProductViewController(ILogger<HomeController> logger, IService<ProductDTO> productService, IService<CategoryDTO> categoryService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
        }

        //GET
        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var products = await _productService.GetDataAsync();
            var categories = await _categoryService.GetDataAsync();
            var viewModel = new ProductDBViewModel()
            {
                Title = "Products",
                Products = products,
                Categories = categories
            };
            return View(productIndex,viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Product(string id)
        {
            var product = await _productService.GetDataByIdAsync(id);
            var viewModel = new ProductDTO()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Rating = product.Rating,
                LastModified = product.LastModified,
                ModifiedBy = product.ModifiedBy
            };
            return View(productIndex, viewModel);
        }

        //POST
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await _categoryService.GetDataAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View(createProduct);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO model)
        {
            if (!ModelState.IsValid)
                return View(createProduct, model);

            var result = await _productService.CreateDataAsync(model);

            if (result)
            {
                TempData["Success"] = "Producto creado exitosamente.";
                return RedirectToAction("Products");
            }

            ModelState.AddModelError("", "Error al crear el Producto.");
            return View(createProduct, model);
        }

        //DELETE
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            bool result = await _productService.DeleteDataAsync(id);

            if (!result)
            {
                TempData["Error"] = "Error al intentar eliminar el Producto.";
                return RedirectToAction("Products");
            }
            TempData["Success"] = "Producto eliminado exitosamente.";
            return RedirectToAction("Products");
        }

        //PUT
        [HttpGet]
        public async Task<IActionResult> EditProduct(string id)
        {
            var product = await _productService.GetDataByIdAsync(id);
            if (product == null)
            {
                TempData["Error"] = "Producto no encontrado.";
                return RedirectToAction("Categories");
            }
            var categories = await _categoryService.GetDataAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View(editProduct, product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(string id, ProductDTO model)
        {
            if (!ModelState.IsValid)
                return View("EditProduct", model);

            bool result = await _productService.PutDataAsync(id, model);

            if (!result)
            {
                ModelState.AddModelError("", "Error al actualizar el producto.");
                return View("EditProduct", model);
            }

            TempData["Success"] = "Producto actualizado exitosamente.";
            return RedirectToAction("Products");
        }

    }
}
