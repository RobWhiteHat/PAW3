using Task = PAW3.Models.Entities.Task;

namespace PAW3.Models.DTO
{
    public class TaskDTO
    {
        public IEnumerable<Task> Tasks { get; set; } = [];

        public List<TaskSummary> TaskSummaries { get; set; } = [];
    }
}
