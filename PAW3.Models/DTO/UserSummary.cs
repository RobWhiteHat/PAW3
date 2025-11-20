namespace PAW3.Models.DTO
{
    public class UserSummary
    {
        public decimal? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal? Value { get; set; }
        public int Count { get; set; }
    }
}