using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using PAW3.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierApiController(ISupplierBusiness supplierBusiness) : ControllerBase
    {
        // GET: api/<SupplierApiController>
        [HttpGet]
        public async Task<IEnumerable<Supplier>> GetAsync()
        {
            return await supplierBusiness.GetSuppliers();
        }

        // GET api/<SupplierApiController>/5
        [HttpGet("{id}")]
        public async Task<Supplier> GetAsync(int id)
        {
            return await supplierBusiness.GetSupplier(id);
        }

        /*
        // POST api/<SupplierApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SupplierApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupplierApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */

    }
}
