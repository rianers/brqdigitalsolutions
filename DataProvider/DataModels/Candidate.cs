using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataProvider.DataModels
{

  public enum GenderType
  {
    Male,
    Female,
    Other,
  }
  [Table("candidates")]
  public class Candidate : Timestamp
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

    [Column("gender")]
    public GenderType Gender { get; set; } = GenderType.Other;

    [Column("birth_at")]
    public DateTime BirthAt { get; set; } = default!;

    public virtual ICollection<Skill> Skills { get; set; } = default!;

    public virtual ICollection<Certification> Certifications { get; set; } = default!;
  }
}
