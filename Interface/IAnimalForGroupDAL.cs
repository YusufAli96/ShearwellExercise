using ShearwellExercise.Models;

namespace ShearwellExercise.Interface
{
    public interface IAnimalForGroupDAL
    {
        Task<bool> Create(List<AnimalForGroup> animalForGroups);
        Task<bool> Delete(AnimalForGroup animalForGroup);
    }
}
