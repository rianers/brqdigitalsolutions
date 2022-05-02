using System.Text.Json.Serialization;
namespace BrqDigitalSolutions.DTOs
{
  public record QueryListCandidateDTO
  {
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("cpf")]
    public string? CPF { get; set; }

    [JsonPropertyName("skills")]
    public List<string>? Skills { get; set; }

    [JsonPropertyName("cetifications")]
    public List<string>? Certifications { get; set; }
  }
}
