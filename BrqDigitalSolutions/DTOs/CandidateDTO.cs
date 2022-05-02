using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BrqDigitalSolutions.Models;
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

    [JsonPropertyName("birth_at")]
    [Required(ErrorMessage = "O campo Data Nascimento é obrigatório.")]
    public DateTime BirthAt { get; set; } = default!;

    [JsonPropertyName("gender")]
    [Required(ErrorMessage = "O campo Genero é obrigatório.")]
    public GenderType Gender { get; set; } = GenderType.Other;

    [JsonPropertyName("skills")]
    [Required(ErrorMessage = "O campo Skills é obrigatório.")]
    public ICollection<string> Skills { get; set; } = default!;

    [JsonPropertyName("certifications")]
    [Required(ErrorMessage = "O campo Certificações é obrigatório.")]
    public ICollection<CertificationDTO> Certifications { get; set; } = default!;
  }
}
