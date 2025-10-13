using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using PAW3.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryApiController(IInventoryBusiness inventoryBusiness) : ControllerBase
    {
        // GET: api/<InventoryApiController>
        [HttpGet]
        public async Task<IEnumerable<Inventory>> GetAsync()
        {
            return await inventoryBusiness.GetInventories();
        }

        // GET api/<InventoryApiController>/5
        [HttpGet("{id}")]
        public async Task<Inventory> GetAsync(int id)
        {
            return await inventoryBusiness.GetInventory(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Inventory inventory)
        {
            bool result = await inventoryBusiness.SaveInventoryAsync(inventory);
            if (!result)
                return BadRequest("Inventory not inserted");

            return Ok($"Inventory #{inventory.InventoryId} created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Inventory inventory)
        {
            if (id != inventory.InventoryId)
                return BadRequest("Inventory not inserted");

            bool result = await inventoryBusiness.UpdateInventoryAsync(inventory);

            if (!result)
                return BadRequest("Inventory not inserted");

            return Ok($"Inventory #{inventory.InventoryId} updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await inventoryBusiness.DeleteInventoryAsync(id);

            if (!result)
                return BadRequest("Inventory not deleted");

            return Ok($"Inventory #{id} deleted");
        }

    }
}
