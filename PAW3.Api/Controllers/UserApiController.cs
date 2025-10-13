using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using PAW3.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController(IUserBusiness userBusiness) : ControllerBase
    {
        // GET: api/<UserApiController>
        [HttpGet]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await userBusiness.GetUsers();
        }

        // GET api/<UserApiController>/5
        [HttpGet("{id}")]
        public async Task<User> GetAsync(int id)
        {
            return await userBusiness.GetUser(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(User user)
        {
            bool result = await userBusiness.SaveUserAsync(user);
            if (!result)
                return BadRequest("User not inserted");

            return Ok($"User #{user.UserId} created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, User user)
        {
            if (id != user.UserId)
                return BadRequest("User not inserted");

            bool result = await userBusiness.UpdateUserAsync(user);

            if (!result)
                return BadRequest("User not inserted");

            return Ok($"User #{user.UserId} updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await userBusiness.DeleteUserAsync(id);

            if (!result)
                return BadRequest("User not deleted");

            return Ok($"User #{id} deleted");
        }

    }
}
