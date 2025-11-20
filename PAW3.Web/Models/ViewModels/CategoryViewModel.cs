using PAW3.Web.Models.Generics;

namespace PAW3.Web.Models.ViewModels;

public class CategoryDtoViewModel
{
    public IEnumerable<CategoryViewModel> Categories { get; set; } = [];
    public List<Generics.SummaryViewModel> Summaries { get; set; } = [];
}

public class CategoryViewModel
{
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public double? Value { get; set; }
    public DateTime? LastModified { get; set; }
    public string? ModifiedBy { get; set; }
}

