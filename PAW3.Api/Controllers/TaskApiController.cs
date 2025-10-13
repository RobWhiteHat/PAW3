using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using PAW3.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskApiController(ITaskBusiness taskBusiness) : ControllerBase
    {
        // GET: api/<TaskApiController>
        [HttpGet]
        public async Task<IEnumerable<Data.Models.Task>> GetAsync()
        {
            return await taskBusiness.GetTasks();
        }

        // GET api/<TaskApiController>/5
        [HttpGet("{id}")]
        public async Task<Data.Models.Task> GetAsync(int id)
        {
            return await taskBusiness.GetTask(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Data.Models.Task task)
        {
            bool result = await taskBusiness.SaveTaskAsync(task);
            if (!result)
                return BadRequest("Task not inserted");

            return Ok($"Task #{task.Id} created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Data.Models.Task task)
        {
            if (id != task.Id)
                return BadRequest("Task not inserted");

            bool result = await taskBusiness.UpdateTaskAsync(task);

            if (!result)
                return BadRequest("Task not inserted");

            return Ok($"Task #{task.Id} updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await taskBusiness.DeleteTaskAsync(id);

            if (!result)
                return BadRequest("Task not deleted");

            return Ok($"Task #{id} deleted");
        }

    }
}
