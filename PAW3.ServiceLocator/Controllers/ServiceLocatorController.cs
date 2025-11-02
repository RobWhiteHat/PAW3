using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Helper;
using PAW3.ServiceLocator.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.ServiceLocator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceLocatorController(IServiceMapper serviceMapper, ICategoryService categoryService) : ServiceControllerBase(serviceMapper, categoryService)
{
    // GET api/<ServiceLocatorController>/5
    [HttpGet("{name}")]
    public async Task<IEnumerable<object>> Get(string name)
    {
        if (ServiceResolvers.TryGetValue(name.ToLower(), out var resolver))
            return await resolver();

        return [];
    }

    [HttpPost("{name}")]
    public async Task<IActionResult> Post(string name, [FromBody] object dto)
    {
        if (dto is null)
            return BadRequest("No body detected");

        if (PostResolvers.TryGetValue(name.ToLower(), out var resolver))
        {
            // Por ejemplo, algunos resolvers podrían aceptar payload
            var result = await resolver(dto);
            return Ok(result);
        }

        return NotFound();
    }

    //[HttpPost("{name}")]
    //public async Task<IEnumerable<object>> Post(string name)
    //{
    //    if (ServiceResolvers.TryGetValue(name.ToLower(), out var resolver))
    //        return await resolver();

    //    return [];
    //}

    /*
    // POST api/<ServiceLocatorController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ServiceLocatorController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ServiceLocatorController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }*/
}
