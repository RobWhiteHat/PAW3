namespace PAW3.Web.Models.ViewModels;

public class UserDtoViewModel
{
    public IEnumerable<UserViewModel> Users { get; set; } = [];
    public List<UserSummaryViewModel> Summaries { get; set; } = [];
}

public class UserSummaryViewModel
{
    public decimal? Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool? IsActive { get; set; }
    public int Count { get; set; }
}
public class UserViewModel
{
    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? LastModified { get; set; }
    public string? ModifiedBy { get; set; }
    public int? RoleId { get; set; }
}

