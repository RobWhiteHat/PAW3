namespace PAW3.Web.Models.ViewModels;

public class ComponentDtoViewModel
{
    public IEnumerable<ComponentViewModel> Components { get; set; } = [];
    public List<ComponentSummaryViewModel> Summaries { get; set; } = [];
}

public class ComponentSummaryViewModel
{
    public decimal? Id { get; set; }
    public string? Name { get; set; }
    public string? Content { get; set; }
    public int Count { get; set; }
}
public class ComponentViewModel
{
    public decimal Id { get; set; }
    public string Name { get; set; } = null!;
    public string Content { get; set; } = null!;
}

