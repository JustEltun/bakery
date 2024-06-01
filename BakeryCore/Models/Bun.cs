using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BakeryCore.Models;

public record Bun
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    [JsonPropertyName("saleTime")]
    public int SaleTimeInHour { get; set; }
    [JsonPropertyName("bakingTime")]
    public DateTime BakingTime { get; set; }
    
    [JsonPropertyName("expiredTime")]
    public DateTime ExpiredTime { get; set; }
    
    [JsonPropertyName("price")]
    public double Price { get; set; }
}
