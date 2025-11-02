using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAW3.Core.BusinessLogic;
using PAW3.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController(ICategoryBusiness categoryBusiness) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await categoryBusiness.GetCategories();
        }

        [HttpGet("{id}")]
        public async Task<Category> GetByAsync(int id)
        {
            return await categoryBusiness.GetCategory(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Category category)
        {
            bool result = await categoryBusiness.SaveCategoryAsync(category);
            if (!result)
                return BadRequest("Category not inserted");

            return Ok($"OK Category #{category.CategoryId} created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Category category)
        {
            category.CategoryId = id;

            bool result = await categoryBusiness.UpdateCategoryAsync(category);

            if (!result)
                return BadRequest("Category not inserted");

            return Ok($"OK Category #{category.CategoryId} updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await categoryBusiness.DeleteCategoryAsync(id);

            if (!result)
                return BadRequest("Category not deleted");

            return Ok($"OK Category #{id} deleted");
        }
    }
}
