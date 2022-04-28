using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
  [Table("certifications")]
  public class Certification: Timestamp
  {
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = default!;

    [Column("description")]
    public string Description { get; set; } = default!;

    [Column("candidate_id")]
    public int CandidateId { get; set; }

    public Candidate Candidate { get; set; } = default!;

    [Column("expedition_at")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
    [DataType(DataType.DateTime)]
    public DateTime ExpeditionAt { get; set; }

    [Column("expiration_at")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
    [DataType(DataType.DateTime)]
    public DateTime? ExpirationAt { get; set; }
  }
}