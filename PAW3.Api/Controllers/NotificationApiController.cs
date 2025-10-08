using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using PAW3.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationApiController(INotificationBusiness notificationBusiness) : ControllerBase
    {
        // GET: api/<NotificationApiController>
        [HttpGet]
        public async Task<IEnumerable<Notification>> GetAsync()
        {
            return await notificationBusiness.GetNotifications();
        }

        // GET api/<NotificationApiController>/5
        [HttpGet("{id}")]
        public async Task<Notification> GetAsync(int id)
        {
            return await notificationBusiness.GetNotification(id);
        }

        /*
        // POST api/<NotificationApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NotificationApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotificationApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */

    }
}
