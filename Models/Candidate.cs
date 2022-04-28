using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
  [Table("candidates")]
  public class Candidate: Timestamp
  {
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = default!;

    [Column("email")]
    public string Email { get; set; } = default!;

    [Column("phone")]
    public string Phone { get; set; } = default!;

    [Column("cpf")]
    public string CPF { get; set; } = default!;

    public IEnumerable<CandidateSkill> Skills { get; set; } = default!;
  }
}