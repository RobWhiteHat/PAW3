namespace PAW3.Models.DTO
{
    public class TaskSummary
    {
        public decimal? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Status { get; set; } 
        public int Count { get; set; }
    }
}