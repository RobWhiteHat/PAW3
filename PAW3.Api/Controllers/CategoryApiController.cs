using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using PAW3.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController(ICategoryBusiness categoryBusiness) : ControllerBase
    {
        // GET: api/<CategoryApiController>
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await categoryBusiness.GetCategories();
        }

        // GET api/<CategoryApiController>/5
        [HttpGet("{id}")]
        public async Task<Category> GetAsync(int id)
        {
            return await categoryBusiness.GetCategory(id);
        }

        /*
        // POST api/<CategoryApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */

    }
}
