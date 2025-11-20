using PAW3.Models.Entities;

namespace PAW3.Models.DTO
{
    public class CategoryDTO
    {
        public IEnumerable<Category> Categories { get; set; } = [];

        public List<Summary> Summaries { get; set; } = [];
    }
}
