using System.ComponentModel.DataAnnotations;

namespace Infocaster.Telemetry.Database.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}