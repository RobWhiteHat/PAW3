using System.Text.Json.Serialization;

namespace PAW3.Models.DTOs;

public partial class NotificationDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; } = null!;

    [JsonPropertyName("isRead")]
    public bool? IsRead { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }
}
