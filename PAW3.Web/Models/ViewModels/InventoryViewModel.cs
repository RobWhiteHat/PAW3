using PAW3.Web.Models.Generics;

namespace PAW3.Web.Models.ViewModels;

public class InventoryDtoViewModel
{
    public IEnumerable<InventoryViewModel> Inventories { get; set; } = [];
    public List<SummaryViewModel> Summaries { get; set; } = [];
}

public class InventoryViewModel
{
    public int InventoryId { get; set; }
    public decimal? UnitPrice { get; set; }
    public int? UnitsInStock { get; set; }
    public DateTime? LastUpdated { get; set; }
    public int? ProductId { get; set; }
    public DateTime? DateAdded { get; set; }
    public string? ModifiedBy { get; set; }
}

