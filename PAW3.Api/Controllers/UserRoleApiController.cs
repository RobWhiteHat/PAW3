using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using PAW3.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleApiController(IUserRoleBusiness userRoleBusiness) : ControllerBase
    {
        // GET: api/<UserRoleApiController>
        [HttpGet]
        public async Task<IEnumerable<UserRole>> GetAsync()
        {
            return await userRoleBusiness.GetUserRoles();
        }

        // GET api/<UserRoleApiController>/5
        [HttpGet("{id}")]
        public async Task<UserRole> GetAsync(int id)
        {
            return await userRoleBusiness.GetUserRole(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(UserRole userRole)
        {
            bool result = await userRoleBusiness.SaveUserRoleAsync(userRole);
            if (!result)
                return BadRequest("User Action not inserted");

            return Ok($"UserRole #{userRole.Id} created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UserRole userRole)
        {
            userRole.Id = id;

            bool result = await userRoleBusiness.UpdateUserRoleAsync(userRole);

            if (!result)
                return BadRequest("User Action not inserted");

            return Ok($"UserRole #{userRole.Id} updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await userRoleBusiness.DeleteUserRoleAsync(id);

            if (!result)
                return BadRequest("User Action not deleted");

            return Ok($"User Action #{id} deleted");
        }

    }
}
