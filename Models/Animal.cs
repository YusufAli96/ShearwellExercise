using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShearwellExercise.Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Tag length must be 12.")]
        public string Tag { get; set; }
        
        [NotMapped]
        public string TagFormat
        {
            get
            {
                if (Tag != null && Tag.Length == 13)
                {
                    return $"UK{Tag.Substring(0, 5)} {Tag.Substring(5)}";
                }
                return string.Empty;
            }
        }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public List<AnimalForGroup> AnimalForGroups { get; set; }
    }
}
