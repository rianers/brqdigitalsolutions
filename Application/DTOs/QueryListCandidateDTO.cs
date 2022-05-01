using System.Text.Json.Serialization;
namespace Application.DTOs
{
  public record QueryListCandidateDTO
  {
    [JsonPropertyName("name")]
    public string? Name { get; set; } = default!;

    [JsonPropertyName("email")]
    public string? Email { get; set; } = default!;

    [JsonPropertyName("cpf")]
    public string? CPF { get; set; } = default!;

    [JsonPropertyName("skills")]
    public List<string>? Skills { get; set; } = default!;

    [JsonPropertyName("cetifications")]
    public List<string>? Certifications { get; set; } = default!;
  }
}
