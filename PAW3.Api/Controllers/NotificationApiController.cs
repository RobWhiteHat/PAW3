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

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Notification notification)
        {
            bool result = await notificationBusiness.SaveNotificationAsync(notification);
            if (!result)
                return BadRequest("Notification not inserted");

            return Ok($"Notification #{notification.Id} created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Notification notification)
        {
            notification.Id = id;

            bool result = await notificationBusiness.UpdateNotificationAsync(notification);

            if (!result)
                return BadRequest("Notification not inserted");

            return Ok($"Notification #{notification.Id} updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await notificationBusiness.DeleteNotificationAsync(id);

            if (!result)
                return BadRequest("Notification not deleted");

            return Ok($"Notification #{id} deleted");
        }

    }
}
