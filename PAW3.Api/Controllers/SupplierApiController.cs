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

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Supplier supplier)
        {
            bool result = await supplierBusiness.SaveSupplierAsync(supplier);
            if (!result)
                return BadRequest("Supplier not inserted");

            return Ok($"Supplier #{supplier.SupplierId} created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Supplier supplier)
        {
            if (id != supplier.SupplierId)
                return BadRequest("Supplier not inserted");

            bool result = await supplierBusiness.UpdateSupplierAsync(supplier);

            if (!result)
                return BadRequest("Supplier not inserted");

            return Ok($"Supplier #{supplier.SupplierId} updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await supplierBusiness.DeleteSupplierAsync(id);

            if (!result)
                return BadRequest("Supplier not deleted");

            return Ok($"Supplier #{id} deleted");
        }

    }
}
