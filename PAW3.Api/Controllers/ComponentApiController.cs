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

        /*
        // POST api/<ComponentApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ComponentApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ComponentApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */

    }
}
