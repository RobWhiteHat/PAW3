using System.Text.Json.Serialization;

namespace PAW3.Models.DTOs
{
    public class InventoryDTO
    {
        [JsonPropertyName("[InventoryId]")]
        public int InventoryId { get; set; }

        [JsonPropertyName("[UnitPrice]")]
        public decimal? UnitPrice { get; set; }

        [JsonPropertyName("[UnitsInStock]")]
        public int? UnitsInStock { get; set; }

        [JsonPropertyName("[LastUpdated]")]
        public DateTime? LastUpdated { get; set; }

        [JsonPropertyName("[ProductId]")]
        public int? ProductId { get; set; }

        [JsonPropertyName("[DateAdded]")]
        public DateTime? DateAdded { get; set; }

        [JsonPropertyName("[ModifiedBy]")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("[Products]")]
        public virtual ICollection<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
