using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using PAW3.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActionApiController(IUserActionBusiness userActionBusiness) : ControllerBase
    {
        // GET: api/<UserActionApiController>
        [HttpGet]
        public async Task<IEnumerable<UserAction>> GetAsync()
        {
            return await userActionBusiness.GetUserActions();
        }

        // GET api/<UserActionApiController>/5
        [HttpGet("{id}")]
        public async Task<UserAction> GetAsync(int id)
        {
            return await userActionBusiness.GetUserAction(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(UserAction userAction)
        {
            bool result = await userActionBusiness.SaveUserActionAsync(userAction);
            if (!result)
                return BadRequest("User Action not inserted");

            return Ok($"UserAction #{userAction.Id} created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UserAction userAction)
        {
            if (id != userAction.Id)
                return BadRequest("User Action not inserted");

            bool result = await userActionBusiness.UpdateUserActionAsync(userAction);

            if (!result)
                return BadRequest("User Action not inserted");

            return Ok($"UserAction #{userAction.Id} updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await userActionBusiness.DeleteUserActionAsync(id);

            if (!result)
                return BadRequest("User Action not deleted");

            return Ok($"User Action #{id} deleted");
        }

    }
}
