using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BrqDigitalSolutions.DTOs
{
  public record CandidateDTO
  {
    [JsonPropertyName("name")]
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string Name { get; set; } = default!;
    [JsonPropertyName("email")]
    [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
    public string Email { get; set; } = default!;

    [JsonPropertyName("phone")]
    [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
    public string Phone { get; set; } = default!;

    [JsonPropertyName("cpf")]
    [Required(ErrorMessage = "O campo CPF é obrigatório.")]
    public string CPF { get; set; } = default!;

    [JsonPropertyName("skills")]
    [Required(ErrorMessage = "O campo Skills é obrigatório.")]
    public IEnumerable<string> Skills { get; set; } = default!;

    [JsonPropertyName("certifications")]
    [Required(ErrorMessage = "O campo Certificações é obrigatório.")]
    public IEnumerable<string> Certifications { get; set; } = default!;
  }
}
