using PAW3.Models.Entities;

namespace PAW3.Models.DTO
{
    public class ComponentDTO
    {
        public IEnumerable<Component> Components { get; set; } = [];
        public List<ComponentSummary> ComSummaries { get; set; } = [];
    }
}
