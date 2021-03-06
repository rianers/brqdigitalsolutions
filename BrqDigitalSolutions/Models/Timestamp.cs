using System.ComponentModel.DataAnnotations.Schema;

namespace BrqDigitalSolutions.Models
{
    abstract public class Timestamp
    {
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
