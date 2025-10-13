using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using PAW3.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController(IProductBusiness productBusiness) : ControllerBase
    {
        // GET: api/<ProductApiController>
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await productBusiness.GetProducts();
        }

        // GET api/<ProductApiController>/5
        [HttpGet("{id}")]
        public async Task<Product> GetAsync(int id)
        {
            return await productBusiness.GetProduct(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Product product)
        {
            bool result = await productBusiness.SaveProductAsync(product);
            if (!result)
                return BadRequest("Product not inserted");

            return Ok($"Product #{product.ProductId} created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Product product)
        {
            if (id != product.ProductId)
                return BadRequest("Product not inserted");

            bool result = await productBusiness.UpdateProductAsync(product);

            if (!result)
                return BadRequest("Product not inserted");

            return Ok($"Product #{product.ProductId} updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await productBusiness.DeleteProductAsync(id);

            if (!result)
                return BadRequest("Product not deleted");

            return Ok($"Product #{id} deleted");
        }
    }
}
