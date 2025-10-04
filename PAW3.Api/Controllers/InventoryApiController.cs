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
        public async Task<IEnumerable<Inventory>> Get()
        {
            return await inventoryBusiness.GetInventories();
        }

        // GET api/<InventoryApiController>/5
        [HttpGet("{id}")]
        public async Task<Inventory> Get(int id)
        {
            return await inventoryBusiness.GetInventory(id);
        }

        // POST api/<InventoryApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InventoryApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InventoryApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
