using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using PAW3.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentApiController(IComponentBusiness componentBusiness) : ControllerBase
    {
        // GET: api/<ComponentApiController>
        [HttpGet]
        public async Task<IEnumerable<Component>> GetAsync()
        {
            return await componentBusiness.GetComponents();
        }

        // GET api/<ComponentApiController>/5
        [HttpGet("{id}")]
        public async Task<Component> GetAsync(int id)
        {
            return await componentBusiness.GetComponent(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Component component)
        {
            bool result = await componentBusiness.SaveComponentAsync(component);
            if (!result)
                return BadRequest("Component not inserted");

            return Ok($"Component #{component.Id} created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Component component)
        {
            if (id != component.Id)
                return BadRequest("Component not inserted");

            bool result = await componentBusiness.UpdateComponentAsync(component);

            if (!result)
                return BadRequest("Component not inserted");

            return Ok($"Component #{component.Id} updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await componentBusiness.DeleteComponentAsync(id);

            if (!result)
                return BadRequest("Component not deleted");

            return Ok($"Component #{id} deleted");
        }

    }
}
