using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using PAW3.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleApiController(IRoleBusiness roleBusiness) : ControllerBase
    {
        // GET: api/<RoleApiController>
        [HttpGet]
        public async Task<IEnumerable<Role>> GetAsync()
        {
            return await roleBusiness.GetRoles();
        }

        // GET api/<RoleApiController>/5
        [HttpGet("{id}")]
        public async Task<Role> GetAsync(int id)
        {
            return await roleBusiness.GetRole(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Role role)
        {
            bool result = await roleBusiness.SaveRoleAsync(role);
            if (!result)
                return BadRequest("Role not inserted");

            return Ok($"Role #{role.RoleId} created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Role role)
        {
            if (id != role.RoleId)
                return BadRequest("Role not inserted");

            bool result = await roleBusiness.UpdateRoleAsync(role);

            if (!result)
                return BadRequest("Role not inserted");

            return Ok($"Role #{role.RoleId} updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await roleBusiness.DeleteRoleAsync(id);

            if (!result)
                return BadRequest("Role not deleted");

            return Ok($"Role #{id} deleted");
        }

    }
}
