using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShearwellExercise.Models
{
    public class AnimalForGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public Guid GroupId { get; set; }
        public DateTime CreatedDateTime { get; set; }

        [ForeignKey(nameof(AnimalId))]
        public Animal Animal { get; set; }

        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; }
    }
}
