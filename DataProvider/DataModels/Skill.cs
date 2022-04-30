using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataProvider.DataModels
{
    [Table("skills")]
    public class Skill : Timestamp
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = default!;

        public ICollection<CandidateSkill> Candidates { get; set; } = default!;
    }
}