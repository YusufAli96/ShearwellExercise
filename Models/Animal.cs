using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShearwellExercise.Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Tag { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<AnimalForGroup> AnimalForGroups { get; set; }
    }
}
